using CraigslistClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public ThreadListingModel Thread { get; set; }
        

    }
}
