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
    public class FileLogic : IFileLogic
    {
        private readonly IFileDao _fileDao;

        private List<int> userFile = new List<int>();

        public FileLogic(IFileDao fileDao)
        {
            _fileDao = fileDao;
        }

        public bool CreateFile(int id, string name, string text)
        {
            if (!String.IsNullOrEmpty(name) &&
                !String.IsNullOrEmpty(text))
            {

                _fileDao.CreateFile(id, name, text);

                return true;
            }
            else
            {
                Console.WriteLine("Incorrect NAME and TEXT (empty)");
                return false;
            }
        }

        public bool Delete(string id)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId))
            {
                if (GetFileById(rightId) != null)
                {
                    _fileDao.DeleteFile(rightId);

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
                Console.WriteLine("Incorrect ID (not number)");
                return false;
            }
        }

        public Files GetFileById(int id)
        {
            return _fileDao.GetFileById(id);
        }

        public IEnumerable<Files> ReadFiles()
        {
            return _fileDao.ReadFiles().ToList();
        }

        public IEnumerable<Files> ReadFilesByUser(string id)
        {
            var result = _fileDao.ReadFilesByUser(Int32.Parse(id));

            foreach (var item in result)
            {
                userFile.Add(item.ID);
            }

            return result;
        }

        public bool UpdateMark(string id, string mark)
        {
            int rightID;
            int rightMark;

            if (Int32.TryParse(id, out rightID) &&
                Int32.TryParse(mark, out rightMark))
            {
                if (GetFileById(rightID) != null)
                {

                    if (rightMark >= 0 &&
                        rightMark <= 10)
                    {
                        _fileDao.UpdateMark(Int32.Parse(id), Int32.Parse(mark));

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect MARK! Mark must be between 0 and 10");
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine("Can't find file");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect ID or MARK (not number");
                return false;
            }
        }

        public bool UpdateText(string id, string text)
        {
            int rightId;

            if (Int32.TryParse(id, out rightId))
            {
                foreach (var item in userFile)
                {
                    if (item == rightId)
                    {
                        _fileDao.UpdateText(rightId, text);
                        return true;
                    }
                } 
            }

            Console.WriteLine("It's not your file!");
            Console.WriteLine();
            return false;
        }

        public bool UpdateTextByAdmin(string id, string text)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId))
            {
                if (GetFileById(rightId) != null)
                {
                    _fileDao.UpdateText(rightId, text);
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
                Console.WriteLine("Incorrect ID (not number)");
                return false;
            }

        }
    }
}
