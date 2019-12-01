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
        //public ApplicationUser User { get; set; }
        public IdentityUser User { get; set; }
        public virtual Thread hostThread { get; set; }
    }
}
