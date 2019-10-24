using Microsoft.AspNetCore.Identity;
using System;

namespace CraigslistClone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int User_ID { get; set; }
        //public string Username { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActive { get; set; }
    }
}
