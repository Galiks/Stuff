using Blog.Models;
using Blogs.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.BLL.Logic
{
    public class BlogLogic : IBlogLogic
    {
        private readonly IBlogDao _blogDao;

        public BlogLogic(IBlogDao blogDao)
        {
            _blogDao = blogDao;
        }

        public bool CreateBlog(string id, string name, string text)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId) &&
                !String.IsNullOrEmpty(name) &&
                !String.IsNullOrEmpty(text))
            {
                _blogDao.CreateBlog(rightId, name, text);
                return true; 
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBlog(string id)
        {
            int rightId;

            if (Int32.TryParse(id, out rightId))
            {
                if (GetBlogById(rightId) != null)
                {

                    _blogDao.DeleteBlog(rightId);

                    return true;  
                }
                else
                {
                    Console.WriteLine("Cna't find blog");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Blog.Models.Blog GetBlogById(int id)
        {
            return _blogDao.GetBlogById(id);
        }

        public IEnumerable<Blog.Models.Blog> GetBlogsByUser(string id)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId))
            {
                return _blogDao.GetBlogsByUser(rightId).ToList();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Blog.Models.Blog> ReadBlogs()
        {
            return _blogDao.ReadBlogs().ToList();
        }

        public bool UpdateBlog(string id, string rating)
        {
            int rightId;
            int rightReting;
            if (Int32.TryParse(id, out rightId) &&
                Int32.TryParse(rating, out rightReting))
            {

                if (GetBlogById(rightId) != null)
                {
                    _blogDao.UpdateBlog(rightId, rightReting);

                    return true;  
                }
                else
                {
                    Console.WriteLine("Can't find blog");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateBlogByAdmin(string id, string name, string text, string rating)
        {
            int rightId;
            int rightRating;

            if (Int32.TryParse(rating, out rightRating))
            {
                if (Int32.TryParse(id, out rightId) &&
                    !String.IsNullOrEmpty(name) &&
                    !String.IsNullOrEmpty(text) &&
                    (rightRating >= 0 && rightRating < 11))
                {
                    if (GetBlogById(rightId) != null)
                    {
                        _blogDao.UpdateBlogByAdmin(rightId, name, text, rightRating);

                        return true;   
                    }
                    else
                    {
                        Console.WriteLine("Can't find blog");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
