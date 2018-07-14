using System.Collections.Generic;
using Blog.Models;

namespace Blogs.DAL.DAO
{
    public interface IBlogDao
    {
        int CreateBlog(int id, string name, string text);
        IEnumerable<Blog.Models.Blog> ReadBlogs();
        Blog.Models.Blog GetBlogById(int id);
        int DeleteBlog(int id);
        int UpdateBlog(int id, int rating);
        int UpdateBlogByAdmin(int id, string name, string text, int rating);
        IEnumerable<Blog.Models.Blog> GetBlogsByUser(int id);
    }
}