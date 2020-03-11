using CraigslistClone.Data;
using CraigslistClone.Models.Entity;
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

        IEnumerable<ListingImage> GetListingImages(int ListingId);

        Thread GetByListing(int id, string userId);
        Task Create(Thread t);
        Task Delete(Thread t);
    }
}
