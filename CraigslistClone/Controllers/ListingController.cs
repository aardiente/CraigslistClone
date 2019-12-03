using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Models.Listing_Model;
using CraigslistClone.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CraigslistClone.Models;

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
        public ListingController( IListing listing, IThread threadService, UserManager<IdentityUser> userManager )
        {
            _listingService = listing;
            _threadService = threadService;
            _userManager = userManager;
        }

        /********************************************************************************/

        // Creates index page of listings
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
                threadId = id
            };

            return View(model);
        }

        // Create listing
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

        [HttpPost]
        public async Task<IActionResult> AddPost(NewListingModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var listing = BuildListing(model, user);

            await _listingService.Add(listing);

            return RedirectToAction("Index", "Listing", new { @id = listing.Id });
        }

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
                hostThreadID = thread.Id
            };
        }

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

        [HttpPost]
        public async Task<IActionResult> EditListing(ListingIndexModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var listing = UpdateListing(model, user);

            await _listingService.EditListing(listing);

            return RedirectToAction("Index", "Listing", new { @id = model.Id });
        }

        private Listing UpdateListing(ListingIndexModel model, IdentityUser user)
        {
            var thread = _threadService.GetByID(model.threadId);

            var listing = thread.Listings.Where(l => l.Id == model.Id).FirstOrDefault();

            listing.Title = model.Title;
            listing.Content = model.ListingContent;
            listing.Created = model.Created;

            return listing;
        }

        [HttpPost]
        public IActionResult SearchResults(string searchQuery)
        {
            var r =_listingService.GetFilteredPost(searchQuery);

            var result = new SearchQueryModel
            {
                results = r,
                query = searchQuery
            };
            return View( result );
        }
    }
}