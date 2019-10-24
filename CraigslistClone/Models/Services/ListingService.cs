using CraigslistClone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Services
{
    public class ListingService : IListing
    {
        private readonly ApplicationDbContext _context;

        public ListingService(ApplicationDbContext context)
        {
            _context = context;
        }

        Listing IListing.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Listing> IListing.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Listing> IListing.GetFilteredPost(string searchQuery)
        {
            throw new NotImplementedException();
        }

        Task IListing.Add(Listing listing)
        {
            throw new NotImplementedException();
        }

        Task IListing.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IListing.EditListingContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Listing> GetListingsByCategory(int id)
        {
            return _context.Categories.Where(category => category.Id == id).FirstOrDefault().Listings;
        }
    }
}
