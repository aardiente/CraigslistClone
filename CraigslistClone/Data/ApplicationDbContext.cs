using System;
using System.Collections.Generic;
using System.Text;
using CraigslistClone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CraigslistClone.Data.Seeds;
using Microsoft.AspNetCore.Identity;

namespace CraigslistClone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add new entities here if needed
        public DbSet<IdentityUser> ApplicationUsers { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Listing> Listings { get; set; }
    }
}
