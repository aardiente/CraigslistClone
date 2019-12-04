using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CraigslistClone.Models;
using CraigslistClone.Data;
using CraigslistClone.Models.Listing_Model;

namespace CraigslistClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController( ApplicationDbContext context )
        {
            _context = context;
        }
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ThreadIndex()
        {
            return View();
        }
        public IActionResult UsersListingIndex()
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
