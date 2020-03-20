using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Listing_Model
{
    public class NewListingModel
    {
        public string ThreadName { get; set; }
        public int ThreadID { get; set; }
        public string AuthorName { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public string Price { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool failedCreate { get; set; }

        public IFormFile[] image { get; set; }
        //public 

    }
}
