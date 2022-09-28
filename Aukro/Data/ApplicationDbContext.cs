using Aukro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aukro.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Auction>? Auctions { get; set; }
        public DbSet<User>? Users { get; set; }
        public ApplicationDbContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=myAuctions.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(new User { Id = 1, Username = "Ruby", Password = "1234" });
            builder.Entity<User>().HasData(new User { Id = 2, Username = "Ruby4", Password = "12345" });


            builder.Entity<Auction>()
                .HasOne(ma => ma.Creator)
                .WithMany(ma => ma.AuctionCreator)
                .HasForeignKey(ma => ma.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Auction>()
               .HasOne(ma => ma.LastUser)
               .WithMany(ma => ma.AuctionLastUser)
               .HasForeignKey(ma => ma.LastUserId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
