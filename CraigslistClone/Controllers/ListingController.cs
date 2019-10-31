using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Models.Listing_Model;
using CraigslistClone.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace CraigslistClone.Controllers
{
    public class ListingController : Controller
    {
        /********************************************************************************/
        // Private handles
        private readonly IListing _listingService;
        private readonly IThread _threadService;

        /********************************************************************************/
        // Constructor
        public ListingController( IListing listing )
        {
            _listingService = listing;
            //_threadService = _listingService.
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
                AuthorId = listing.User.Id,// Causing a crash. Null refrence exception
                AuthorName = listing.User.UserName,
                Created = listing.Created,
                Expires = listing.Expires,
                ListingContent = listing.Content
            };

            return View(model);
        }

        // Create listing
        public IActionResult Create(int id)
        {
            var thread = _threadService.GetByID(id);

            var model = new NewListingModel
            {
                ThreadName = thread.Title,
                ThreadID = thread.Id,
                AuthorName = User.Identity.Name // Gets the current logged in user
            };
            return View(model);
        }
    }
}