﻿using Microsoft.EntityFrameworkCore;
using TatBlog.Core.Entities;
using TatBlog.Data.Mappings;

namespace TatBlog.Data.Contexts
{
    public class BlogDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        //Bạn phải thay đổi chuổi kết nối cho phù hợp
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TatBlog;
            Trusted_Connection=True;MultipleActiveResultSets=True,TrustServerCetificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CategoryMap).Assembly);
    }
}
}
