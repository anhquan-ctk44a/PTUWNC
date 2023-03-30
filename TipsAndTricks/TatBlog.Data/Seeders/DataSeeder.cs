//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TatBlog.Core.Entities;
//using TatBlog.Data.Contexts;

//namespace TatBlog.Data.Seeders 
//{
//    public class DataSeeder : IDataSeeder
//    {
//        private readonly BlogDbContext _dbContext;

//        public DataSeeder(BlogDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public void Initialize()
//        {
//            _dbContext.Database.EnsureCreated();

//            if (_dbContext.Posts.Any()) return;

//            var authors = AddAuthors();
//            var categories = AddCategories();
//            var tags = AddTags();
//            var posts = AddPosts(authors, categories, tags);
//        }
//        private IList<Author> AddAuthors()
//        {
//            var authors = new List<Author>()
//             {
//                new()
//                {
//                    FullName = "Jason Mouth",
//                    UrlSlug = "jason-mouth",
//                    Email = "json@gmail.com",
//                    JoinedDate = new DateTime(2022, 10, 21)
//                },
//                new()
//                {
//                    FullName = "Jessica Wonder",
//                    UrlSlug = "jessica-wonder",
//                    Email = "jessica665@motip.com",
//                    JoinedDate = new DateTime(2020, 4, 19)
//                }
//             };
//            _dbContext.Authors.AddRange(authors);
//            _dbContext.SaveChanges();

//            return authors;
//        }

//        private IList<Category> AddCategories()
//        {
//            var categories = new List<Category>()
//             {
//                new() { Name = ".NET Core", Description = ".NET Core", UrlSlug }
//                new() { Name = "Architecture", Description = "Architecture", UrlSlug }
//                new() { Name = "Messaging", Description = "Messaging", UrlSlug }
//                new() { Name = "OOP", Description = "Object-Oriented Program", UrlSlug }
//                new() { Name = "Design Patterns", Description = "Design Patterns", UrlSlug }
//             };
//            _dbContext.AddRange(categories);
//            _dbContext.SaveChanges();

//            return categories;

//        }

//        private IList<Tag> AddTags()
//        {
//            var tags = new List<Tag>()
//            {

//            }
//        }

//        private IList<Post> AddPosts(
//            IList<Author> authors,
//            IList<Category> categories,
//            IList<Tag> tags)
//        { }

//    }
//}

  

