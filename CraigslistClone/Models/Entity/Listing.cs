using CraigslistClone.Models.Entity;
using CraigslistClone.Models.Listing_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models
{
    public class Listing
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
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

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
