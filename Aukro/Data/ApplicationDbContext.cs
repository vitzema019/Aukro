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
            builder.Entity<Auction>().HasData(new Auction { AuctionId = 1, MinimumPrice = 5, Name = "Stolička", Description = "Vhodná na sezení", Category = "Nábytek", DateOfCreation = new DateTime(2022, 09, 21), DateOfEnd = new DateTime(2012, 09, 22), CreatorId = 1, LastUserId = 1 });

            builder.Entity<Auction>()
                .HasOne(ma => ma.Creator)
                .WithMany(ma => ma.AuctionCreator)
                .HasForeignKey(ma => ma.CreatorId);

            builder.Entity<Auction>()
               .HasOne(ma => ma.LastUser)
               .WithMany(ma => ma.AuctionLastUser)
               .HasForeignKey(ma => ma.LastUserId);

           
        }
    }
}
