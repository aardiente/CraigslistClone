using CraigslistClone.Models;
using System;

namespace CraigslistClone.Views.Listings
{
    public class ListingPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AuthorID { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public CategoryListingModel Category { get; set; }
    }
}
