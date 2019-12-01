using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CraigslistClone.Models.Services
{
    public class ThreadService : IThread
    {
        private readonly ApplicationDbContext _context;

        public ThreadService( ApplicationDbContext context )
        {
            _context = context;
        }

        Thread IThread.GetByID(int ID)
        {
            var thread = _context.Threads
                .Where(t => t.Id == ID)
                .Include(t => t.Listings)
                //.ThenInclude(t => t.UsersID) // This may be incorrect we want listings // comment out if broken
                    .FirstOrDefault();
            var test = _context.Threads
                .Where(t => t.Id == ID);

            return thread;
        }

        IEnumerable<Thread> IThread.GetAll()
        {
            return _context.Threads.Include( Thread => Thread.Listings );
        }

        IEnumerable<IdentityUser> IThread.GetApplicationUsers()
        {
            throw new NotImplementedException();
        }

        Task IThread.Create(Thread listing)
        {
            throw new NotImplementedException();
        }

        Task IThread.Delete(Thread t)
        {
            throw new NotImplementedException();
        }
    }
}
