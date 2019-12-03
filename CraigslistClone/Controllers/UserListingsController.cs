using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Models.Listing_Model;
using CraigslistClone.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CraigslistClone.Controllers
{
    public class UserListingsController : Controller
    {
        /********************************************************************************/
        // Private handles
        private readonly IListing _listingService;
        private static UserManager<IdentityUser> _userManager;

        /********************************************************************************/
        // Constructor
        public UserListingsController(IListing listing, UserManager<IdentityUser> userManager)
        {
            _listingService = listing;
            _userManager = userManager;
        }

        /********************************************************************************/
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var UsersListings = _listingService.GetListingsByUser(userId);

            var model = new UserListingsModel
            {
                UserListings = UsersListings.OrderByDescending(l => l.Created),
                CurrentUser = user
            };

            return View(model);
        }
    }
}
