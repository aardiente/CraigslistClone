using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Listing_Model
{
    public class NewListingModel
    {
        public string ThreadName { get; set; }
        public int ThreadID { get; set; }
        public string AuthorName { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string Price { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFile[] image { get; set; }
        //public 

    }
}
