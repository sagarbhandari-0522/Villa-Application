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
                entity.HasData(
                    new Room
                    {
                        Id=1,
                        Name="Royal Villa",
                        Description= "A luxurious villa with a sea view.",
                        Price=500,
                        Sqft=1200,
                        Occupancy=4,
                        ImageUrl="",
                        CreatedAt=DateTime.UtcNow,
                        UpdatedAt=DateTime.UtcNow
                    },
                    new Room
                    {
                        Id=2,
                        Name="Mountaind Retreat",
                        Description="A cozy cabin in the mountains",
                        Price=500,
                        Sqft=800,
                        Occupancy=2,
                        ImageUrl="",
                        CreatedAt=DateTime.UtcNow,
                        UpdatedAt=DateTime.UtcNow
                    }

                 );
            });

        }
        public DbSet<Room> Villas { get; set; }

    }
  
        


}
