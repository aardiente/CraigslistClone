using CraigslistClone.Views.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models
{
    public class ThreadTopicModel
    {
        public ThreadListingModel Thread { get; set; }
        public IEnumerable<ListingPostModel> Listings { get; set; }
    }
}
