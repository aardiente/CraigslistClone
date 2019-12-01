using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public ThreadController( IThread threadService ) // May need to move service into seperate layer
        {
            _ThreadService = threadService;
        }

        /********************************************************************************/
        // Controller functionality

        // Index page for all categories
        public IActionResult Index()
        {
            var Threads = _ThreadService.GetAll().OrderBy(s => s.Title) // IEnumberable<Thread> // Get all Threads from db
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
        public IActionResult Topic(int id)
        {
            var thread = _ThreadService.GetByID(id); // Computers has an id of 3
            var listings = thread.Listings;// _ListingService.GetListingsByThread(id);  // returns a null value exception. its not getting thread.id

            var postListings = listings.Select(listing => new ListingPostModel
            {
                Id = listing.Id,
                //AuthorID = listing.User.Id, // as it stands null
                Title = listing.Title,
                PostDate = listing.Created,
                ExpireDate = listing.Expires,
                Thread = BuildThreadListing(listing)
            });

            var model = new ThreadTopicModel
            {
                Listings = postListings,
                Thread = BuildThreadListing(thread)
            };

            return View(model);
        }

        private ThreadListingModel BuildThreadListing(Listing listing)
        {
            var thread = listing.hostThread;

            return BuildThreadListing(thread);
        }
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