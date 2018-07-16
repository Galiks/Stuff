using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile.BLL.Interface
{
    public interface IUserLogic
    {
        bool CreateUser(string name, string password);
        bool CreateUserByAdmin(string name, string password, string role);
        bool DeleteUser(string id);
        User GetUserById(int id);
        IEnumerable<User> ReadUsers();
        bool UpdateUser(string id, string name, string password);
        bool UpdateUserById(string id, string role);
        User SignIn(string name, string password);
    }
}
