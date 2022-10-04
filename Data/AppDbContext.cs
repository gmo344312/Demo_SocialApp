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
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<PostLikers> PostLikers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tbUser");
                entity.HasKey(u => u.id);
                entity.HasMany<Posts>(u => u.Posts).WithOnene(p => p.Author).HasForeignKey(p => p.AuthorId).IsRequired(false);
                entity.HasMany<Comment>(p => p.Comment).WithOnene(c => c.Author).HasForeignKey(c => c.AuthorId);
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("tbPost");
                entity.HasKey(p => p.id);
                entity.HasOne<User>(p => p.Author).WithMany(u => u.Posts).HasForeignKey(u => u.AuthorId).IsRequired(true);
                entity.HasOne<Group>(p => p.Group).WithMany(g => g.Posts).HasForeignKey(p => p.GroupId);
                entity.HasMany<Comment>(p => p.Comment).WithOne(c => c.Posts).HasForeignKey(p => p.PostId);
            });
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("tbGroup");
                entity.HasKey(g=> g.Id);
                entity.HasMany<Posts>(g => g.Posts).WithOne(p => p.Group).HasForeignKey(g => g.GroupId);
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("tbComment");
                entity.HasKey(c=> c.Id);
                entity.HasOne<User>(p => p.Author).WithMany<Comment>(c=> c.Comment).HasForeignKey(c=> c.AuthorId).IsRequired(true);
                entity.HasOne<Posts>(c => c.Post).WithMany<Comment>(p=> p.Comment).HasForeignKey(c=> c.PostId).IsRequired(true);
            });
            modelBuilder.Entity<PostLikers>(entity =>
            {
                entity.ToTable("tbPostLikers");
                entity.HasKey(k => new{ k.PostId,k.UserId});
                entity.HasOne<User>(u => u.User).WithMany(u=>u.Posts).HasForeignKey(u=>u.UserId);
                entity.HasOne<Posts>(p => p.Posts).WithMany(u => u.PostLikers).HasForeignKey(g => g.PostIdId);
            });
            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("tbUserGroup");
                entity.HasKey(k => new{ k.UserId,k.GroupId});
                entity.HasOne<User>(g => g.User).WithMany(u=>u.UserGroup).HasForeignKey(g=>g.UserId);
                entity.HasOne<Posts>(u => u.Group).WithMany(g => g.UserinGroup).HasForeignKey(ug => ug.GroupId);
            });
        }
    }

}