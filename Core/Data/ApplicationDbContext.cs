using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aisalesbot.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CheckOut>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(9,2)");
            builder.Entity<UserCart>()
           .Property(o => o.Discount)
           .HasColumnType("decimal(9,2)");

            builder.Entity<CheckOut>()
               .HasOne(s => s.ShipmentDetails)
               .WithOne(b => b.CheckOut)
               .HasForeignKey<ShipmentDetails>(e => e.CheckOutId);

          
        }
        public DbSet<UserCart> UserCart { get; set; }
        public DbSet<CheckOut> CheckOut { get; set; }
        public DbSet<ShipmentDetails> ShipmentDetails { get; set; }
    }
}
