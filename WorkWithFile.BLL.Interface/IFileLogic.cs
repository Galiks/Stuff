using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile.BLL.Interface
{
    public interface IFileLogic
    {
        bool CreateFile(int id, string name, string text);
        Files GetFileById(int id);
        IEnumerable<Files> ReadFiles();
        IEnumerable<Files> ReadFilesByUser(string id);
        bool UpdateMark(string id, string mark);
        bool UpdateText(string id, string text);
        bool Delete(string id);
        bool UpdateTextByAdmin(string id, string text);
    }
}
