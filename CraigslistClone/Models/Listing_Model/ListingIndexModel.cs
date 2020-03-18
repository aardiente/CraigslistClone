using CraigslistClone.Models.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Listing_Model
{
    public class ListingIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public string ListingContent { get; set; }
        public int threadId { get; set; }

        public string Price { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        //public IFormFile image { get; set; }
        public byte[] image { get; set; }
        public IEnumerable<ListingImage> Images { get; set; }
    }
}
