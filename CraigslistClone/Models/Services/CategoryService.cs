using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CraigslistClone.Models.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        Category ICategory.GetByID(int ID)
        {
            var category = _context.Categories.Where(t => t.Id == ID)
                                   .Include(t => t.Listings)
                                    //.ThenInclude(l => l.UserName) // This may be incorrect we want listings
                                   .FirstOrDefault();

            return category;
        }

        IEnumerable<Category> ICategory.GetAll()
        {
            return _context.Categories.Include(Category => Category.Listings);
        }

        IEnumerable<IdentityUser> ICategory.GetApplicationUsers()
        {
            throw new NotImplementedException();
        }

        Task ICategory.Create(Category listing)
        {
            throw new NotImplementedException();
        }

        Task ICategory.Delete(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
