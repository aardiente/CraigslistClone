using CraigslistClone.Models.Entity;
using CraigslistClone.Models.Listing_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }

        public string UsersID { get; set; }
        public IdentityUser User { get; set; } // Was previously ApplicationUser User
        public virtual Thread hostThread { get; set; }
        public int hostThreadID { get; set; }

        // New stuff
        public Byte[] image { get; set; }

        //public ListingImages images{ get; set; }

        public IEnumerable<ListingImage> images { get; set; }
        public string Price { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
