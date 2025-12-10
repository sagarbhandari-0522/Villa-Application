
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Villas.Any())
            {
                return;
            }

            var royalVilla = new Room
            {
                Name = "Royal Villa",
                Description = "A luxurious villa with a sea view.",
                Price = 500,
                Sqft = 1200,
                Occupancy = 4,
                ImageUrl = "https://placehold.co/600x400",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var mountainRetreat = new Room
            {
                Name = "Mountain Retreat",
                Description = "A cozy cabin in the mountains",
                Price = 500,
                Sqft = 800,
                Occupancy = 2,
                ImageUrl = "https://placehold.co/600x401",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Villas.AddRange(royalVilla, mountainRetreat);
            context.SaveChanges();
            var villaNumbers = new VillaNumber[]
                {
                   new VillaNumber
                    {
                        Villa_Number = 101,
                        VillaId = royalVilla.Id,
                        SpecialDetails = "Best Numebr of this Villa"

                    },
                   new VillaNumber
                    {
                        Villa_Number = 102,
                        VillaId = royalVilla.Id,
                        SpecialDetails = "Front Face Room"

                    },
                   new VillaNumber
                    {
                        Villa_Number = 201,
                        VillaId = mountainRetreat.Id,
                        SpecialDetails = "DIrect to Sunlight"
                    },

                   new VillaNumber
                    {
                        Villa_Number = 202,
                        VillaId = mountainRetreat.Id,
                        SpecialDetails = "Good View from WIndow"
                    }
                };
            context.VillaNumbers.AddRange(villaNumbers);
            context.SaveChanges();

        }

    }
}
