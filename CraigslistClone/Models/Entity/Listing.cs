using System;

namespace CraigslistClone.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Category HostCategory { get; set; }
    }
}
