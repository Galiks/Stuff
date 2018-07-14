using System.Collections.Generic;
using Blog.Models;

namespace Blogs.BLL.Logic
{
    public interface IBlogLogic
    {
        bool CreateBlog(string id, string name, string text);
        IEnumerable<Blog.Models.Blog> ReadBlogs();
        Blog.Models.Blog GetBlogById(int id);
        bool DeleteBlog(string id);
        bool UpdateBlog(string id, string rating);
        bool UpdateBlogByAdmin(string id, string name, string text, string rating);
        IEnumerable<Blog.Models.Blog> GetBlogsByUser(string id);
    }
}