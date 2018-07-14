using Blog.Models;
using Blogs.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public bool CreateUser(string name, string password)
        {
            _userDao.CreateUser(name, password);

            return true;
        }

        public bool CreateUserByAdmin(string name, string password, int role)
        {
            _userDao.CreateUserbyAdmin(name, password, role);
            return true;
        }

        public bool DeleteUser(string id)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId))
            {
                if (GetUserById(rightId) != null)
                {
                    _userDao.DeleteUser(rightId);

                    return true;
                }
                else
                {
                    Console.WriteLine("Cant't find user");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public IEnumerable<User> ReadUsers()
        {
            return _userDao.ReadUsers().ToList();
        }

        public IEnumerable<User> ReadUsersByAdmin()
        {
            return _userDao.ReadUsersByAdmin().ToList();
        }

        public User SignIn(string name, string password)
        {
            foreach (var item in ReadUsersByAdmin())
            {
                if ((item.Name == name) && (item.Password == password))
                {
                    Console.WriteLine($"Welcome {item.Name} !!!");
                    return item;
                }
            }
            Console.WriteLine("DB has no infirmation about you. Please, Sign on");
            return SignOn();
        }

        public bool UpdateUser(string id, string name, string password)
        {
            int rightId;
            if (Int32.TryParse(id, out rightId) &&
                !String.IsNullOrEmpty(name) &&
                !String.IsNullOrEmpty(password))
            {

                if (GetUserById(rightId) != null)
                {
                    _userDao.UpdateUser(rightId, name, password);

                    return true;
                }
                else
                {
                    Console.WriteLine("Cant't find user");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateUserByAdmin(string id, string name, string password, string role)
        {
            int rightId;
            int rightRole;
            if (Int32.TryParse(role, out rightRole))
            {
                if (Int32.TryParse(id, out rightId) &&
                !String.IsNullOrEmpty(name) &&
                !String.IsNullOrEmpty(password) && 
                (rightRole > 0 && rightRole < 4))
                {

                    if (GetUserById(rightId) != null)
                    {
                        _userDao.UpdateUserByAdmin(rightId, name, password, rightRole);

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Cant't find user");
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

        private User SignOn()
        {
            Console.Write("Name: ");
            var signOnName = Console.ReadLine();
            Console.Write("Password: ");
            var signOnPssword = Console.ReadLine();
            CreateUser(signOnName, signOnPssword);

            return ReadUsers().Last();
        }
    }
}
