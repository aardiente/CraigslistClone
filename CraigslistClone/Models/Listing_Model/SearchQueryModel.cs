using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Listing_Model
{
    public class SearchQueryModel
    {
        public IEnumerable<Listing> results;
        public string query;
    }
}
