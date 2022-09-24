using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasKey(k => new { k.AppUserId, k.PostId });

            modelBuilder.Entity<Like>()
                .HasOne(u => u.User)
                .WithMany(l => l.Likes)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Comment>()
               .HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}