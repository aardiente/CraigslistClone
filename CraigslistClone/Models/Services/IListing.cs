using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Services
{
    public interface IListing
    {
        Listing GetByID(int id);
        IEnumerable<Listing> GetAll();
        IEnumerable<Listing> GetFilteredPost(string searchQuery);

        Task Add(Listing listing);
        Task Delete(int id);
        Task EditListingContent(int id, string newContent);

        IEnumerable<Listing> GetListingsByThread(int id);
    }
}
