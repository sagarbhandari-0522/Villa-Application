
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Room> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(v => v.Price).HasPrecision(10, 2);
                entity.Property(v => v.Sqft).HasPrecision(10, 2);

            });
            modelBuilder.Entity<VillaNumber>()
                .HasOne(vn => vn.Room)
                .WithMany(v => v.VillaNumbers)
                .HasForeignKey(vn => vn.VillaId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Room>().HasData(
            //    new Room
            //    {
            //        Id = 1,
            //        Name = "Royal Villa",
            //        Description = "A luxurious villa with a sea view.",
            //        Price = 500,
            //        Sqft = 1200,
            //        Occupancy = 4,
            //        ImageUrl = "https://placehold.co/600x400",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new Room
            //    {
            //        Id = 2,
            //        Name = "Mountain Retreat",
            //        Description = "A cozy cabin in the mountains",
            //        Price = 500,
            //        Sqft = 800,
            //        Occupancy = 2,
            //        ImageUrl = "https://placehold.co/600x401",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    }
            //);
            //modelBuilder.Entity<VillaNumber>().HasData(

            //    new VillaNumber
            //    {
            //        Villa_Number = 101,
            //        VillaId = 1,
            //        SpecialDetails = "Best Numebr of this Villa"

            //    },
            //    new VillaNumber
            //    {
            //        Villa_Number = 102,
            //        VillaId = 1,
            //        SpecialDetails = "Front Face Room"

            //    },
            //    new VillaNumber
            //    {
            //        Villa_Number = 201,
            //        VillaId = 2,
            //        SpecialDetails = "DIrect to Sunlight"
            //    },

            //    new VillaNumber
            //    {
            //        Villa_Number = 202,
            //        VillaId = 2,
            //        SpecialDetails = "Good View from WIndow"
            //    }
            //);
        }
    }
}
