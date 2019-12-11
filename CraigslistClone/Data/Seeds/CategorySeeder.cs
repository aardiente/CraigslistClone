using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Models;
using Microsoft.AspNetCore.Identity;

namespace CraigslistClone.Data.Seeds
{
    public static class CategorySeeder
    {

        /// <summary>
        ///     Creates a few threads to be seeded to the DB on the first run.
        /// </summary>
        /// <param name="context"> DbContext </param>
        public static void SeedCategories(ApplicationDbContext context)
        {
            if (!context.Threads.Any())
            {
                // Refactor this to categories
                var threads = new List<Thread>
                {
                    new Thread{ Title = "Computers", Description = "Need a new computer? Find one here!", Created = DateTime.Today },
                    new Thread{ Title = "Cars", Description = "If the wheels on the bus aren't cutting it, get a sweet new ride here!", Created = DateTime.Today },
                    new Thread{ Title = "Toys", Description = "Getting bored? Find something to play with! Don't be gross though.", Created = DateTime.Today },
                    new Thread{ Title = "Jobs", Description = "Grandma's Christmas Gift isn't going to buy itself!", Created = DateTime.Today },
                    new Thread{ Title = "Sports", Description = "Do you like to get hot and sweaty? Buy some new gear!", Created = DateTime.Today },
                    new Thread{ Title = "Lost Connections", Description = "Trying to find that girl you bumped into at Starbucks? I guess you could try looking here", Created = DateTime.Today },
                    new Thread{ Title = "Housing", Description = "Tired of living in that crappy overpriced apartment? ", Created = DateTime.Today },
                    new Thread{ Title = "Gigs", Description = "Does your Beatles cover band need a place to play? Check us out", Created = DateTime.Today }
                };

                context.AddRange(threads);
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Seeds a user and a few listings for that user into the Db on first run.
        /// </summary>
        /// <param name="context"> DbContext </param>
        public static void SeedExampleUser(ApplicationDbContext context)
        {
            if (!context.ApplicationUsers.Any())
            {
                // Create basic user
                var user = new ApplicationUser
                {
                    UserName = "test@email.com",
                    NormalizedUserName = "test@email.com",
                    Email = "test@email.com",
                    NormalizedEmail = "test@email.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                // Create password
                var hasher = new PasswordHasher<ApplicationUser>();
                var hashedPassword = hasher.HashPassword(user, "test");

                user.PasswordHash = hashedPassword;

                // Refactor this to categories
                var Listings = new List<Listing>
                {
                    new Listing
                    {               Title = "Gaming PC",
                                    Content = "Core i5 9600K\n16 GB DDR4 3200mhz\nXFX RX 580 8gb\nGigabyte Gaming SLI MOBO\nCooler Master H100",
                                    Created = DateTime.Today,
                                    Expires = DateTime.Today.AddDays(7),
                                    hostThread = context.Threads.Where( t => t.Title == "Computers" ).FirstOrDefault(),
                                    hostThreadID = context.Threads.Where( t => t.Title == "Computers" ).FirstOrDefault().Id,
                                    UsersID = user.Id,
                                    User = user
                    },
                    new Listing
                    {               Title = "School Laptop",
                                    Content = "It only takes 30 seconds to load microsoft word.\n$1600 WILL NOT BUDGE ON PRICE",
                                    Created = DateTime.Today,
                                    Expires = DateTime.Today.AddDays(7),
                                    hostThread = context.Threads.Where( t => t.Title == "Computers" ).FirstOrDefault(),
                                    hostThreadID = context.Threads.Where( t => t.Title == "Computers" ).FirstOrDefault().Id,
                                    UsersID = user.Id,
                                    User = user
                    },
                    new Listing
                    {               Title = "Looking for death metal band to play at church gathering",
                                    Content = "Be brutal... THIS ISN'T YOUR GRANDMA'S CHURCH GATHERING",
                                    Created = DateTime.Today.AddDays(-5),
                                    Expires = DateTime.Today.AddDays(2),
                                    hostThread = context.Threads.Where( t => t.Title == "Gigs" ).FirstOrDefault(),
                                    hostThreadID = context.Threads.Where( t => t.Title == "Gigs" ).FirstOrDefault().Id,
                                    UsersID = user.Id,
                                    User = user
                    },
                    new Listing
                    {               Title = "Manchester United (2010) Jersey ",
                                    Content = "Barely worn.",
                                    Created = DateTime.Today.AddDays(-5),
                                    Expires = DateTime.Today.AddDays(2),
                                    hostThread = context.Threads.Where( t => t.Title == "Sports" ).FirstOrDefault(),
                                    hostThreadID = context.Threads.Where( t => t.Title == "Sports" ).FirstOrDefault().Id,
                                    UsersID = user.Id,
                                    User = user
                    },
                    new Listing
                    {               Title = "Guy who wanted to 1v1 me in CoD at walmart",
                                    Content = "Rust, quickscopes only. COME AT ME. PSN: xXxNoscopeGoDxXx",
                                    Created = DateTime.Today.AddDays(-5),
                                    Expires = DateTime.Today.AddDays(2),
                                    hostThread = context.Threads.Where( t => t.Title == "Lost Connections" ).FirstOrDefault(),
                                    hostThreadID = context.Threads.Where( t => t.Title == "Lost Connections" ).FirstOrDefault().Id,
                                    UsersID = user.Id,
                                    User = user
                    },
                    new Listing
                    {               Title = "Hotwheels collection",
                                    Content = "My mom said I'm too old (32) for hotwheels and is making me sell them $5000 obo",
                                    Created = DateTime.Today.AddDays(-5),
                                    Expires = DateTime.Today.AddDays(2),
                                    hostThread = context.Threads.Where( t => t.Title == "Toys" ).FirstOrDefault(),
                                    hostThreadID = context.Threads.Where( t => t.Title == "Toys" ).FirstOrDefault().Id,
                                    UsersID = user.Id,
                                    User = user
                    },
                    new Listing
                    {               Title = "Looking for clown/performer for childs birthday",
                                    Content = "He really loves jonny karate",
                                    Created = DateTime.Today.AddDays(-5),
                                    Expires = DateTime.Today.AddDays(2),
                                    hostThread = context.Threads.Where( t => t.Title == "Gigs" ).FirstOrDefault(),
                                    hostThreadID = context.Threads.Where( t => t.Title == "Gigs" ).FirstOrDefault().Id,
                                    UsersID = user.Id,
                                    User = user
                    }
                };

                context.Add(user);
                context.AddRange(Listings);
                context.SaveChanges();
            }
        }
    }
}
