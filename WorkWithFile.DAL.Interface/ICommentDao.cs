using System.Collections.Generic;
using Entity;

namespace WorkWithFile.DAL.DAO
{
    public interface ICommentDao
    {
        int CreateComment(int id, string comment);
        IEnumerable<Comment> ReadCommentByFile(int id);
    }
}