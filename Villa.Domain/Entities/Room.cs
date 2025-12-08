using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Domain.Entities
{
    public class Room
    {
        public int Id { get;set; }
        public required string Name { get;set; }     
        public string? Description { get;set; }
        [Display(Name="Price Per Night")]
        public decimal Price { get; set; }
        public decimal Sqft { get; set; }
        public int Occupancy { get; set; }
        [Display(Name="Image Url")]
        public  string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
