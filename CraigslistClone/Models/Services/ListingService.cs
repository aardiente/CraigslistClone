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
                .Include( listing => listing.hostThread )
                .First();
        }

        IEnumerable<Listing> IListing.GetAll()
        {
            return _context.Listings
                .Include(listing => listing.User)
                .Include(listing => listing.hostThread);
        }
        IEnumerable<Listing> IListing.GetListingsByUser( string userId )
        {
            var userListings = _context.Listings.Where( listing => listing.User.Id == userId);
            return userListings;
        }

        IEnumerable<Listing> IListing.GetFilteredPost(string searchQuery)
        {
            throw new NotImplementedException();
        }

        async Task  IListing.Add(Listing listing)
        {
            _context.Add(listing);
            await _context.SaveChangesAsync();
        }

        Task IListing.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task IListing.EditListing(Listing listing)
        {
            _context.Update(listing);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Listing> GetListingsByThread(int id)
        {
            return _context.Threads.Where(thread => thread.Id == id).FirstOrDefault().Listings;
        }
        public Thread GetHostThread(int id)
        {
            var t = _context.Threads.Where(thread => thread.Id == id).FirstOrDefault();
            return t;

        }
    }
}
