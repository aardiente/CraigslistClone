using CraigslistClone.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Services
{
    public interface IThread
    { 
        Thread GetByID(int ID);
        IEnumerable<Thread> GetAll();
        IEnumerable<IdentityUser> GetApplicationUsers();

        Thread GetByListing(int id, string userId);
        Task Create(Thread t);
        Task Delete(Thread t);
    }
}
