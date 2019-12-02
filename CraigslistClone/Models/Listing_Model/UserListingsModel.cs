using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Listing_Model
{
    public class UserListingsModel
    {
        public IdentityUser CurrentUser;
        public IEnumerable<Listing> UserListings;
    }
}
