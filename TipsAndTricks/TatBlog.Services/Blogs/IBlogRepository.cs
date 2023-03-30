using System.Threading.Tasks;
using System.Threading;
using TatBlog.Core.Contracts;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs 
{
    public interface IBlogRepository
    {
        //Tìm bài viết có tên định là slug
        //và được đăng vào tháng năm

        Task<Post> GetPostAsync(
            int year,
            int month,
            string slug,
            CancellationToken cancellationToken = default);

        //Tìm top N bài viết được nhiều người xem nhất
        Task<IList<Post>> GetPopularArticlesAsync(
            int numPosts,
            CancellationToken cancellationToken = default);

        //Tăng số lượt xem của một bài viết
        Task IncreaseViewCountAsync(
            int postId, string slug,
            CancellationToken cancellationToken = default);
        //Tăng số lượt xem của một bài viết
        Task IncreaseViewCountAsync(
            int postId,
            CancellationToken cancellationToken = default);
        //Lấy danh sách chuyên mục và số lượng bài viết
        //nằm thuộc từng chuyên mục/chủ đề
        Task<IList<CategoryItem>> GetCategoriesAsync(
            bool showOnMenu = false,
            CancellatonToken cancellationToken = default);
        //Lấy danh sách khóa thẻ và phân trang theo các tham số pagingparam
        Task<IPagedList<TagItem>> GetPagedTagsAsync(
       IPagingParams pagingParams, 
       CancellationToken cancellationToken = default);
    }
}


    

