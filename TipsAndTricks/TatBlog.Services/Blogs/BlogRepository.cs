using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using TatBlog.Core.Contracts;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _context;
    public BlogRepository(BlogDbContext context)
    {
        _context = context;
    }
    //Tìm bài viết có tên định danh là slug
    //và được đăng vào tháng năm

    public Task<Post> GetPostAsync(
        int year,
        int month,
        string slug,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Post> postsQuery = _context.Set<Post>()
               .Include(x => x.Category)
               .Include(x => x.Author);
        if (year > 0)
        {
            postsQuery = postsQuery.Where(x => x.PostedDate.Year == year);
        }
        if (month > 0)
        {
            postsQuery = postsQuery.Where(x => x.PostedDate.Month == month);
        }
        if (!string.IsNullOrWhiteSpace(slug))
        {
            postsQuery = postsQuery.Where(x => x.UrlSlug == slug);
        }
        return await postsQuery.FirstOrDefaultAsync(cancellationToken);
    }
    //Tìm top N bài viết phổ biến được nhiều người xem nhất
    public Task<IList<Post>> GetPopularArticleAsync(
        int numPosts, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Post>()
        .Include(x => x.Author)
        .Include(x => x.Category)
        .OrderByDescending(p => p.ViewCount)
        .Take(numPosts)
        .ToListAsync(cancellationToken);
    }
    //Kiểm tra xem tên định danh của bài viết đã có hay chưa
    public Task<bool> IsPostSlugExistedAsync(
        int postId,
        string slug,
        CancellationToken cancellationToken = default)
    {
        return await _context.Set<Post>()
            .AnyAsync(x => x.Id != postId && x.UrlSlug == slug,
                cancellationToken);
    }
    //Tăng số lượt xem của một bài viết
    public async Task IncreaseViewCount(
        int postId,
        CancellationToken cancellationToken = default)
    {
        await _context.Set<Post>()
            .Where(x => x.Id == postId)
            .ExecuteUpdateAsync(p =>
                p.SetProperty(x => x.ViewCount, x => x.ViewCount + 1),
                cancellationToken);
    }

    //Lấy danh sách chuyên mục và số lượng bài viết 
    //nằm thuộc từng chuyên mục/chủ đề

    public async Task<IList<CategoryItem>> GetCategoriesAsync(
       bool showOnMenu = false,
       CancellationToken cancellationToken = default)
    {
        IQueryable<Category> categories = _context.Set<Category>();

        if (showOnMenu)
        {
            categories = categories.Where(x => x.ShowOnMenu);
        }
    }
}

// Lấy danh sách từ khóa/ thẻ và phân trang theo các tham số pagingParams
public async Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, CancellationToken cancellationToken = default)
{
    var tagQuery = _context.Set<Tag>()
        .Select(x => new TagItem()
        {
            Id = x.Id,
            Name = x.Name,
            UrlSlug = x.UrlSlug,
            Description = x.Description,
            PostCount = x.Posts.Count(p => p.Published)
        });

    return await tagQuery.ToPagedListAsync(pagingParams, cancellationToken);
}
