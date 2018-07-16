using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile.BLL.Interface
{
    public interface ICommentLogic
    {
        bool CreateComment(string id, string comment);
        IEnumerable<Comment> ReadCommentByFile(string id);
    }
}
