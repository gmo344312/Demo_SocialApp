using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocielApp_Demo.Models;

namespace SocielApp_Demo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tbUser");
                entity.HasMany<Post>(u => u.UserPost);
                entity.HasMany<UserGroup>(u => u.UserGroups);
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("tbPost");
                entity.HasOne<User>(p => p.Author)
                .WithMany(p => p.UserPost)
                .HasForeignKey(p => p.AuthorId);
                entity.HasOne<Group>(p => p.Group).WithMany(g => g.Post).HasForeignKey(g => g.GroupId);
                entity.HasMany<User>(p => p.Likers);
                entity.HasMany<Comment>(p => p.Comment).WithOne(p => p.Post).HasForeignKey(p => p.PostId);
            });
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("tbGroup");
                entity.HasMany<UserGroup>(g => g.UserinGroups);
                entity.HasMany<Post>(g => g.Post).WithOne(p => p.Group).HasForeignKey(g => g.GroupId);
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("tbComment");
                entity.HasOne<User>(p => p.Author);
                entity.HasOne<Post>(c => c.Post);
            });
            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("tbUserGroup");
                entity.HasKey<>
                entity.HasMany<UserGroup>(g => g.UserinGroups);
                entity.HasMany<Post>(g => g.Post).WithOne(p => p.Group).HasForeignKey(g => g.GroupId);
            });
        }
    }

}