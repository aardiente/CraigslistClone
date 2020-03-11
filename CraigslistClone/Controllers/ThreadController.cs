using System.Linq;
using CraigslistClone.Models;
using CraigslistClone.Models.Services;
using CraigslistClone.Views.Listings;
using Microsoft.AspNetCore.Mvc;

namespace CraigslistClone.Controllers
{
    public class ThreadController : Controller
    {
        /********************************************************************************/
        // Private handles

        private readonly IThread _ThreadService;

        /********************************************************************************/
        // Constructor
        
        /// <summary>
        ///     Non default constructor for ThreadController
        /// </summary>
        /// <param name="threadService"> Thread Service Layer </param>
        public ThreadController( IThread threadService ) 
        {
            _ThreadService = threadService;
        }

        /********************************************************************************/
        // Controller functionality

        // Index page for all categories
        /// <summary>
        ///     Index page for all the Categories (threads)
        /// </summary>
        /// <returns> ThreadIndexModel: List of threads </returns>
        public IActionResult Index()
        {
            var Threads = _ThreadService.GetAll().OrderBy(s => s.Title)
                .Select( threads => new ThreadListingModel 
                { 
                    Id = threads.Id, 
                    Name = threads.Title, 
                    Description = threads.Description 
                });

            var model = new ThreadIndexModel
            {
                ThreadList = Threads
            };

            return View(model);
        }

        // Displays Listings of a given category
        /// <summary>
        ///     Takes you to the listings for a given category
        /// </summary>
        /// <param name="id"> ThreadId </param>
        /// <returns> View with all the listings </returns>
        public IActionResult Topic(int id)
        {
            var thread = _ThreadService.GetByID(id);
            var listings = thread.Listings;

            var postListings = listings.Select(listing => new ListingPostModel
            {
                Id = listing.Id,
                //AuthorID = listing.User.Id, // as it stands null
                Title = listing.Title,
                PostDate = listing.Created,
                ExpireDate = listing.Expires,
                image = listing.image,
                Images = _ThreadService.GetListingImages(listing.Id),
                Thread = BuildThreadListing(listing)
            });

            //var t = postListings.First().Images; // Testing variable

            var model = new ThreadTopicModel
            {
                Listings = postListings,
                Thread = BuildThreadListing(thread)
            };

            return View(model);
        }

        /// <summary>
        ///     A helper function that builds a thread to be given to a post listing model
        /// </summary>
        /// <param name="listing"> listing the thread is being built for </param>
        /// <returns></returns>
        private ThreadListingModel BuildThreadListing(Listing listing)
        {
            var thread = listing.hostThread;

            return BuildThreadListing(thread);
        }

        /// <summary>
        ///     Overloaded method for BuildThreadListing(Listing) to take a thread instead.
        /// </summary>
        /// <param name="t"> Thread being passed </param>
        /// <returns> ThreadListingModel </returns>
        private ThreadListingModel BuildThreadListing(Thread t)
        {
            return new ThreadListingModel
            {
                Id = t.Id,
                Name = t.Title,
                
                Description = t.Description
            };
        }
    }
}