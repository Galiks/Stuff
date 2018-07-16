using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using WorkWithFile.BLL.Interface;
using WorkWithFile.DAL.DAO;

namespace WorkWithFile.BLL.Logic
{
    public class CommentLogic : ICommentLogic
    {
        private readonly ICommentDao _commentDao;
        private readonly IFileDao _fileDao;

        public CommentLogic(ICommentDao commentDao, IFileDao fileDao)
        {
            _commentDao = commentDao;
            _fileDao = fileDao;
        }

        public bool CreateComment(string id, string comment)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId) &&
                !String.IsNullOrEmpty(comment))
            {
                if (_fileDao.GetFileById(rightId) != null)
                {

                    _commentDao.CreateComment(rightId, comment);

                    return true;

                }
                else
                {
                    Console.WriteLine("Can't find file");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect ID (not number) or incorrect comment (empty)");
                return false;
            }
        }

        public IEnumerable<Comment> ReadCommentByFile(string id)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId))
            {
                if (_fileDao.GetFileById(rightId) != null)
                {

                    return _commentDao.ReadCommentByFile(rightId).ToList();

                }
                else
                {
                    Console.WriteLine("Can't find file");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Incorrect ID (not number)");
                return null;
            }
        }
    }
}
