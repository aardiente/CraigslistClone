using CraigslistClone.Data;
using CraigslistClone.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Services
{
    public class ListingService : IListing
    {
        /************************************************************************************************/
        // Private Handles

        private readonly ApplicationDbContext _context;

        /************************************************************************************************/
        // Constructors

        /// <summary>
        ///     Non default constructor for Listing service layer
        /// </summary>
        /// <param name="context"> DbContext </param>
        public ListingService( ApplicationDbContext context )
        {
            _context = context;
        }

        /************************************************************************************************/

        /// <summary>
        ///     Gets a Listing by its id from the Db
        /// </summary>
        /// <param name="id"> Listing Id </param>
        /// <returns> Reference to that listing </returns>
        Listing IListing.GetByID(int id)
        {
            return _context.Listings.Where( listing => listing.Id == id )
                .Include( listing => listing.User )
                .Include( listing => listing.hostThread )
                .First();
        }

        /// <summary>
        ///     Get all listings from the database
        /// </summary>
        /// <returns> IEnumberable: All listings </returns>
        IEnumerable<Listing> IListing.GetAll()
        {
            return _context.Listings
                .Include(listing => listing.User)
                .Include(listing => listing.hostThread);
        }

        /// <summary>
        ///     Get a Listing by a User's ID
        /// </summary>
        /// <param name="userId"> UserId </param>
        /// <returns> IEnumberable: Listings created by that user </returns>
        IEnumerable<Listing> IListing.GetListingsByUser( string userId )
        {
            var userListings = _context.Listings
                .Where(listing => listing.User.Id == userId);
                //.Include(l => l.hostThreadID);

            return userListings;
        }

        /// <summary>
        ///     Gets listings that matches a search query. (searchbar)
        /// </summary>
        /// <param name="searchQuery"> query </param>
        /// <returns> IEnumberable: All listings that match that query </returns>
        IEnumerable<Listing> IListing.GetFilteredPost(string searchQuery)
        {
            List<Listing> results = new List<Listing>(); // Holds the results

            if (!string.IsNullOrEmpty(searchQuery)) // Can't search for a nothing
            {
                foreach (Thread t in _context.Threads.Where(l => l.Listings != null).Include(l => l.Listings).ToList()) // Go through all listings in each category and check if they match
                {
                    var tListings = t.Listings.Where(l => l.Title.ToUpper().Contains(searchQuery.ToUpper())); // Compare titles

                    results.AddRange(tListings.ToList()); // Add matching results to results
                }

                if (!results.Any()) // If we don't have any results, see if we have a category that matches
                {
                    var matchingThreads = _context.Threads.Where(t => t.Title.ToUpper().Contains(searchQuery.ToUpper())).ToList();

                    if (matchingThreads.Any())
                        results = matchingThreads.First().Listings.ToList();
                }
            }

            return results;
        }

        /// <summary>
        ///     Add a listing to the Database
        /// </summary>
        /// <param name="listing"> Listing being added </param>
        /// <returns> async task </returns>
        async Task IListing.Add(Listing listing)
        {
            _context.Add(listing);

            if (listing.images != null)
            {
                foreach (ListingImage obj in listing.images)
                {
                    obj.ListingId = listing.Id;
                    _context.Add(obj);
                }
            }

            await _context.SaveChangesAsync();
        }


        /************************************************************************************************/
        // Unused, will be implimented if i continue the project

        async Task IListing.Delete(int id)
        {
            var listing =_context.Listings.Find(id);
            var images = _context.ListingImages.Where( img => img.ListingId == id ).ToList();

            _context.Listings.Remove(listing);

            if(images.Count > 0)
            {
                foreach (var img in images)
                {
                    _context.ListingImages.Remove(img);
                }
            }

            await _context.SaveChangesAsync();
        }
        /************************************************************************************************/

        /// <summary>
        ///     Edit the listing on the database. This will be done before being passed to this method.
        /// </summary>
        /// <param name="listing"> Listing being updated </param>
        /// <returns> async task </returns>
        async Task IListing.EditListing(Listing listing)
        {
            _context.Update(listing);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Gets Listings by a ThreadId
        /// </summary>
        /// <param name="id"> ThreadId </param>
        /// <returns> IEnumberable: Listings that are in the given thread </returns>
        public IEnumerable<Listing> GetListingsByThread(int id)
        {
            return _context.Threads.Where(thread => thread.Id == id).FirstOrDefault().Listings;
        }

        /// <summary>
        ///     Get the hostThread for a listing by the listingId
        /// </summary>
        /// <param name="id"> ListingId </param>
        /// <returns> The Host thread </returns>
        public Thread GetHostThread(int id)
        {
            var t = _context.Threads.Where(thread => thread.Id == id)
                .FirstOrDefault();

            return t;
        }

        IEnumerable<ListingImage> IListing.GetListingImages( int ListingId )
        {
            var userListings = _context.Listings
                .Where(listing => listing.Id == ListingId)
                .Include(listing => listing.images);

            return userListings.First().images;
        }
    }
}
