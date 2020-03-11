using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models.Entity
{
    public class ListingImage
    {
        [Key]
        public int Id { get; set; }
        public byte[] Data { get; set; }

        [ForeignKey( "UserId" )]
        public string UserId { get; set; }

        [ForeignKey("ListingId")]
        public int ListingId { get; set; }

        [ForeignKey("ThreadId")]
        public int ThreadId { get; set; }
    }
}
