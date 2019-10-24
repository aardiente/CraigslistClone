using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Services
{
    public interface ICategory
    {
        Category GetByID(int ID);
        IEnumerable<Category> GetAll();
        IEnumerable<IdentityUser> GetApplicationUsers();

        Task Create(Category t);
        Task Delete(Category t);
    }
}
