using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Data;
using CraigslistClone.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CraigslistClone.Models.Services
{
    public class ThreadService : IThread
    {
        /************************************************************************************************/
        // Private handles

        private readonly ApplicationDbContext _context;

        /************************************************************************************************/
        // Constructors

        /// <summary>
        ///     Non default constructor for our Thread Service Layer
        /// </summary>
        /// <param name="context"> DbContext </param>
        public ThreadService( ApplicationDbContext context )
        {
            _context = context;
        }

        /************************************************************************************************/

        /// <summary>
        ///     Gets a thread from the database by a given Id
        /// </summary>
        /// <param name="ID"> ThreadId </param>
        /// <returns> Thread: a reference to a thread object </returns>
        Thread IThread.GetByID(int ID)
        {
            var thread = _context.Threads
                .Where(t => t.Id == ID)
                .Include(t => t.Listings)
                    .FirstOrDefault();

            var test = _context.Threads
                .Where(t => t.Id == ID);

            return thread;
        }

        /// <summary>
        ///     Gets a listing by a thread id and a userid.
        ///     <NOTE> This is currently unused </NOTE>
        /// </summary>
        /// <param name="id"> ThreadId </param>
        /// <param name="userId"> UserId </param>
        /// <returns></returns>
        Thread IThread.GetByListing(int id, string userId)
        {
            var thread = _context.Threads;

            return null;
        }

        /// <summary>
        ///     This gets all the threads stored in the database
        /// </summary>
        /// <returns> A IEnumberable of threads with their listings attached. </returns>
        IEnumerable<Thread> IThread.GetAll()
        {
            return _context.Threads.Include( Thread => Thread.Listings );
        }

        /// <summary>
        ///     Gets the listing images of the given listing
        /// </summary>
        /// <param name="ListingId"> Listing to look for </param>
        /// <returns></returns>
        IEnumerable<ListingImage> IThread.GetListingImages(int ListingId)
        {
            var userListings = _context.Listings
                .Where(listing => listing.Id == ListingId)
                .Include(listing => listing.images);

            return userListings.First().images;
        }


        /************************************************************************************************/
        // Unused for now, will be implimented if I work on this project in the future.
        IEnumerable<IdentityUser> IThread.GetApplicationUsers()
        {
            throw new NotImplementedException();
        }

        Task IThread.Create(Thread listing) // Doesn't make sense for a user to create a listing category
        {
            throw new NotImplementedException();
        }

        Task IThread.Delete(Thread t) // Deleting a category is a bad idea.
        {
            throw new NotImplementedException();
        }
    }
}
