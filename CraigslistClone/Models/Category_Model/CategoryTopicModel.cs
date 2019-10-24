using CraigslistClone.Views.Listings;
using System.Collections.Generic;

namespace CraigslistClone.Models
{
    public class CategoryTopicModel
    {
        public CategoryListingModel Category { get; set; }
        public IEnumerable<ListingPostModel> Listings { get; set; }
    }
}
