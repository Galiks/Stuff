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
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public bool CreateUser(string name, string password)
        {

            if (!String.IsNullOrEmpty(name)&&
                !String.IsNullOrEmpty(password))
            {
                _userDao.CreateUser(name, password);

                return true; 
            }
            else
            {
                Console.WriteLine("Incorrect name or password");
                return false;
            }
        }

        public bool CreateUserByAdmin(string name, string password, string role)
        {
            _userDao.CreateUserByAdmin(name, password, Int32.Parse(role));

            return true;
        }

        public bool DeleteUser(string id)
        {
            _userDao.DeleteUser(Int32.Parse(id));

            return true;
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public IEnumerable<User> ReadUsers()
        {
            return _userDao.ReadUsers().ToList();
        }

        public bool UpdateUser(string id, string name, string password)
        {
            _userDao.UpdateUser(Int32.Parse(id), name, password);

            return true;
        }

        public bool UpdateUserById(string id, string role)
        {
            int rightId;
            int rightRole;
            if (Int32.TryParse(id, out rightId) &&
                Int32.TryParse(role, out rightRole))
            {

                if (GetUserById(rightId) != null &&
                    (rightRole >= 1 &&
                    rightRole <=3))
                {
                    _userDao.UpdateUserById(rightId, rightRole);
                    return true;  
                }
                else
                {
                    Console.WriteLine("Can't find file or Incorect role (role must be between 1 and 3)");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect ID or ROLE (not number)");
                return false;
            }
        }

        public User SignIn(string name, string password)
        {
            foreach (var item in ReadUsers())
            {
                if ((item.Name == name) && (item.Password == password))
                {
                    Console.WriteLine($"Welcome {item.Name}");
                    return item;
                }
            }
            Console.WriteLine("DB has no infirmation about you. Please, Sign on");
            return SignOn();
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
