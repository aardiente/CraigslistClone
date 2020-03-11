using System;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Models.Listing_Model;
using CraigslistClone.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CraigslistClone.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using CraigslistClone.Models.Entity;
using System.Collections.Generic;

namespace CraigslistClone.Controllers
{
    public class ListingController : Controller
    {
        /********************************************************************************/
        // Private handles
        private readonly IListing _listingService;
        private readonly IThread _threadService;
        private static UserManager<IdentityUser> _userManager;

        /********************************************************************************/
        // Constructor

        /// <summary>
        ///     Non-Default controller for Listing Controller, it initializes services.
        /// </summary>
        /// <param name="listing"> Listing Service </param>
        /// <param name="threadService"> Thread Service </param>
        /// <param name="userManager"> UserManagement tool </param>
        public ListingController( IListing listing, IThread threadService, UserManager<IdentityUser> userManager )
        {
            _listingService = listing;
            _threadService = threadService;
            _userManager = userManager;
        }

        /********************************************************************************/

        // Creates index page of listings
        /// <summary>
        ///     Takes a ThreadId and uses that to generate a view, by passing in a ListinIndexModel which is just a container class for a listing.
        /// </summary>
        /// <param name="id"> ThreadId </param>
        /// <returns> ListingIndexModel: Container class for listing  </returns>
        public IActionResult Index(int id)
        {
            var listing = _listingService.GetByID(id);

            var model = new ListingIndexModel
            {
                Id = listing.Id,
                Title = listing.Title,
                AuthorId = listing.User.Id,
                AuthorName = listing.User.UserName,
                Created = listing.Created,
                Expires = listing.Expires,
                ListingContent = listing.Content,
                threadId = id,
                Images = _listingService.GetListingImages(listing.Id),
                image = listing.image//convertByteArrayToFormFile(listing.image)
            };

            return View(model);
        }

        private IFormFile convertByteArrayToFormFile( byte[] file )
        {
            if (file != null)
            {
                using (var stream = new MemoryStream(file))
                {
                    IFormFile temp = new FormFile(stream, 0, file.Length, "name", "filename");
                    return temp;
                }
            }
            else return null;
        }
        
        /// <summary>
        ///     Takes a ThreadID and sends the user to a create a listing page
        /// </summary>
        /// <param name="id"> ThreadId </param>
        /// <returns> NewListingModel: A container for some Thread information and the currently logged in user. </returns>
        public IActionResult Create(int id)
        {
            var thread = _listingService.GetHostThread(id);

            var model = new NewListingModel
            {
                ThreadName = thread.Title,
                ThreadID = thread.Id,
                AuthorName = User.Identity.Name // Gets the current logged in user
            };
            return View(model);
        }

        /// <summary>
        ///     An HTTP post method that takes in a newly created listing, created in the method above (Create)
        ///     and pushes that new listing to the database.
        /// </summary>
        /// <param name="model"> The newly created listing made by the user. </param>
        /// <returns> Redirects the user to the listing they just made. </returns>
        [HttpPost]
        public async Task<IActionResult> AddPost(NewListingModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var listing = BuildListing(model, user);

            await _listingService.Add(listing);

            return RedirectToAction("Index", "Listing", new { @id = listing.Id });
        }

        /// <summary>
        ///     A helper method for AddPost which actually creates the listing.
        /// </summary>
        /// <param name="model"> listing being created </param>
        /// <param name="user"> user that created it </param>
        /// <returns></returns>
        private Listing BuildListing(NewListingModel model, IdentityUser user)
        {
            var thread = _threadService.GetByID(model.ThreadID);

            return new Listing
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(7),
                User = user,
                UsersID = user.Id,
                hostThread = thread,
                hostThreadID = thread.Id,
                images = ConvertListingImages(model.image, model.ThreadID, user.Id),
                image = ConvertIFormFileToByteArray(model.image.First())
            };
        }
        
        private List<ListingImage> ConvertListingImages( IFormFile[] files, int ThreadId, string UserId )
        {
            List<ListingImage> result = new List<ListingImage>();

            foreach( IFormFile f in files )
            {
                result.Add(new ListingImage
                {
                    ThreadId = ThreadId,
                    UserId = UserId,
                    Data = ConvertIFormFileToByteArray(f)
                }) ;
            }

            return result;
        }
        private byte[] ConvertIFormFileToByteArray( IFormFile image )
        {
            // Solution found at: https://stackoverflow.com/questions/42741170/how-to-save-images-to-database-using-asp-net-core
            if ( image != null )
            {
                if (image.Length > 0)
                {
                    byte[] result = null;

                    using ( var fileStream = image.OpenReadStream() )
                    using ( var memoryStream = new MemoryStream() )
                    {
                        fileStream.CopyTo(memoryStream);
                        result = memoryStream.ToArray();
                    }

                    return result;
                }
            }

            return null; // Default to null if theres no file.
        }

        /// <summary>
        ///     Directs the user to the edit page for the listing they have clicked on.
        /// </summary>
        /// <param name="id"> ThreadId </param>
        /// <returns> ListingIndexModel: the model being edited </returns>
        public IActionResult Edit(int id)
        {
            var listing = _listingService.GetByID(id);

            var model = new ListingIndexModel
            {
                Id = listing.Id,
                Title = listing.Title,
                AuthorId = listing.User.Id,
                AuthorName = listing.User.UserName,
                Created = listing.Created,
                Expires = listing.Expires,
                ListingContent = listing.Content,
                threadId = listing.hostThread.Id
            };

            return View(model);
        }

        /// <summary>
        ///     HTTP Post method for a listing that has been edited by its creator
        /// </summary>
        /// <param name="model"> The listing that's been edited </param>
        /// <returns> Redirects the user to the edited listing </returns>
        [HttpPost]
        public async Task<IActionResult> EditListing(ListingIndexModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var listing = UpdateListing(model, user);

            await _listingService.EditListing(listing);

            return RedirectToAction("Index", "Listing", new { @id = model.Id });
        }

        /// <summary>
        ///     A helper method for EditListing that actually changes the properties in the listing.
        /// </summary>
        /// <param name="model"> Listing being edited </param>
        /// <param name="user"> The user edititing the listing </param>
        /// <returns></returns>
        private Listing UpdateListing(ListingIndexModel model, IdentityUser user) // user isn't used atm but will be in the future if I continue this project
        {
            var thread = _threadService.GetByID(model.threadId);

            var listing = thread.Listings.Where(l => l.Id == model.Id).FirstOrDefault();

            listing.Title = model.Title;
            listing.Content = model.ListingContent;
            listing.Created = model.Created;

            return listing;
        }

        /// <summary>
        ///     HttpPost method that interacts with the ThreadController. 
        ///     <NOTE> It is here because it didn't make sense to impliment a listing service in my thread controller for one method, and it's returning a view of just listings. </NOTE>
        /// </summary>
        /// <param name="searchQuery"> User's search query </param>
        /// <returns> Returns a view with the search results. </returns>
        [HttpPost]
        public IActionResult SearchResults(string searchQuery)
        {
            var r = _listingService.GetFilteredPost(searchQuery);

            var result = new SearchQueryModel
            {
                results = r,
                query = searchQuery
            };
            return View( result );
        }
    }
}