using System.Linq;
using CraigslistClone.Models;
using CraigslistClone.Models.Services;
using CraigslistClone.Views.Listings;
using Microsoft.AspNetCore.Mvc;

namespace CraigslistClone.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _CategoryService;
        private readonly IListing _ListingService;


        public CategoryController(ICategory categoryService) // May need to move service into separate layer
        {
            this._CategoryService = categoryService;
        }

        public IActionResult Index()
        {
            var Categories = _CategoryService.GetAll() // IEnumerable<Category> // Get all Categories from db
                                             .Select(threads => new CategoryListingModel
                                              {
                                                  Id = threads.Id,
                                                  Name = threads.Title,
                                                  Description = threads.Description
                                              });

            var model = new CategoryIndexModel
            {
                CategoryList = Categories
            };

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var category = _CategoryService.GetByID(id); // Computers has an id of 3
            var listings = category.Listings; // _ListingService.GetListingsByThread(id);  // returns a null value exception. its not getting category.id

            var postListings = listings.Select(listing => new ListingPostModel
            {
                Id = listing.Id,
                AuthorID = listing.User.User_ID,
                Title = listing.Title,
                PostDate = listing.Created,
                ExpireDate = listing.Expires,
                Category = BuildCategoryListing(listing)
            });

            var model = new CategoryTopicModel
            {
                Listings = postListings,
                Category = BuildCategoryListing(category)
            };

            return View(model);
        }

        private CategoryListingModel BuildCategoryListing(Listing listing)
        {
            var category = listing.HostCategory;

            return BuildCategoryListing(listing);
        }

        private CategoryListingModel BuildCategoryListing(Category t)
        {
            return new CategoryListingModel
            {
                Id = t.Id,
                Name = t.Title,
                Description = t.Description
            };
        }
    }
}
