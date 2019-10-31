using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraigslistClone.Models;

namespace CraigslistClone.Data.Seeds
{
    public class CategorySeeder
    {
        public static void SeedCategories(ApplicationDbContext context)
        {
            if (!context.Threads.Any())
            {
                // Refactor this to categories
                var threads = new List<Thread>
                {
                    new Thread{ Title = "Computers", Description = "For all of your pc needs", Created = DateTime.Today },
                    new Thread{ Title = "Cars", Description = "For all of your car needs", Created = DateTime.Today },
                    new Thread{ Title = "Toys", Description = "For all of your toy needs", Created = DateTime.Today },
                    new Thread{ Title = "Jobs", Description = "For all of your employment needs", Created = DateTime.Today },
                    new Thread{ Title = "Sports", Description = "For all of your sporting good needs", Created = DateTime.Today },
                };

                context.AddRange(threads);
                context.SaveChanges();
            }
        }
    }
}
