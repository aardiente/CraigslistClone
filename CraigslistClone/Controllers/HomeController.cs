using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CraigslistClone.Models;
using CraigslistClone.Data;
using CraigslistClone.Models.Listing_Model;

namespace CraigslistClone.Controllers
{
    public class HomeController : Controller
    {
        /********************************************************************************/
        // Private handles
        private readonly ApplicationDbContext _context;

        /********************************************************************************/
        // Constructors

        /// <summary>
        ///     Non default constructor for HomeController
        /// </summary>
        /// <param name="context"> DbContext </param>
        public HomeController( ApplicationDbContext context )
        {
            _context = context;
        }

        /********************************************************************************/

        /// <summary>
        ///     Landing page atm.
        /// </summary>
        /// <returns> RecentListingModel: All listings created in the last day. </returns>
        public IActionResult Index()
        {
            var Threads = _context.Threads;

            var Listings = _context.Listings
                    .Where(l => l.Created >= DateTime.Now.AddDays(-1)) // Gets all postings from yesterday at the current time.
                    .OrderByDescending(l => l.Created);

            var model = new RecentListingModel
            {
                recentListings = Listings.Take(5).ToList(),
                threads = Threads
            };

            return View(model);

        }


        // These are all bare bones and I don't feel like commenting them. 
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ThreadIndex()
        {
            return View();
        }
        public IActionResult UsersListingIndex() // Directs you to user listing index
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
