using System;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WinApp;
//Tạo đối tượng DbContext để quản lý phiên làm việc
//Với CSDL và trạng thái của các đối tượng
var context = new BlogDbContext();

//Đọc danh sách bài viết từ cơ sở dữ liệu
//Lấy kèm tên tác giả và chuyên mục
//var posts = context.Posts
//    .Where(p => p.Published)
//    .OrderBy(p => p.Title)
//    .Select(p => new
//    {
//        Id = p.Id,
//        Title = p.Title,
//        ViewCount = p.ViewCount,
//        PostedDate = p.PostedDate,
//        Author = p.Author.FullName,
//        Category = p.Category.Name
//    })
//    .ToList();

//Tạo đối tượng BlorRepository
IBlogRepository blogRepo = new BlogRepository(context);
////Tìm 3 bài viết được xem/đọc nhiều nhất
//var posts = await blogRepo.GetPopularArticleAsync(3);
////Xuất danh sách bài viết ra màn hình

//foreach (var post in posts)
//{
//    Console.WriteLine("Id      : {0}", post.Id);
//    Console.WriteLine("Title   : {0}", post.Title);
//    Console.WriteLine("View    : {0}", post.ViewCount);
//    Console.WriteLine("Date    : {0:MM/dd/yyyy}", post.PostedDate);
//    Console.WriteLine("Author  : {0}", post.Author);
//    Console.WriteLine("Category: {0}", post.Category);
//    Console.WriteLine("".PadRight(80,'-'));

//}

// Lấy danh sách chuyên mục
//var categories = await blogRepo.GetCategoriesAsync();

//// xuất ra màn hình
//Console.WriteLine("{0,-5}{1,-50}{2,10}", 
//    "Id", "Name", "Count");

//foreach (var item in categories)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}",
//        item.Id, item.Name, item.PostCount);

//}
var context = new BlogDbContext();

IBlogRepository blogRepo = new BlogRepository(context);

var pagingParams = new PagingParams
{
    PageNumber = 1,
    PageSize = 5,
    SortColumn = "Name",
    SortOrder = "DESC"
};

var tagsList = await blogRepo.GetPagedTagsAsync(pagingParams);
Console.WriteLine("{0,-5}{1,-50}{2,10}",
    "ID", "Name", "Count");

foreach (var item in tagsList)
{
    Console.WriteLine("{ 0,-5}{ 1,-50}{ 2,10})",
        item.Id, item.Name, item.PostCount);
}

