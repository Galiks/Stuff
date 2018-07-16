using System.Collections.Generic;
using Entity;

namespace WorkWithFile.DAL.DAO
{
    public interface IFileDao
    {
        int CreateFile(int id, string name, string text);
        Files GetFileById(int id);
        IEnumerable<Files> ReadFiles();
        IEnumerable<Files> ReadFilesByUser(int id);
        int UpdateMark(int id, int mark);
        int UpdateText(int id, string text);
        int DeleteFile(int id);
    }
}