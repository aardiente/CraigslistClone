using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CraigslistClone.Models
{
    [Table("Threads")]
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Listing> Listings { get; set; }
    }
}
