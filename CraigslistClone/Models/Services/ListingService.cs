using CraigslistClone.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Services
{
    public class ListingService : IListing
    {
        private readonly ApplicationDbContext _context;

        public ListingService( ApplicationDbContext context )
        {
            _context = context;
        }

        Listing IListing.GetByID(int id)
        {
            return _context.Listings.Where( listing => listing.Id == id )
                .Include( listing => listing.User )
                .Include( listing=> listing.hostThread )
                .First();
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

        public IEnumerable<Listing> GetListingsByThread(int id)
        {
            return _context.Threads.Where(thread => thread.Id == id).FirstOrDefault().Listings;
        }
    }
}
