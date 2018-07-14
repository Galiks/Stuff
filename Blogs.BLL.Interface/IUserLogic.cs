using System.Collections.Generic;
using Blog.Models;

namespace Blogs.BLL.Logic
{
    public interface IUserLogic
    {
        bool CreateUserByAdmin(string name, string password, int role);
        bool CreateUser(string name, string password);
        IEnumerable<User> ReadUsers();
        IEnumerable<User> ReadUsersByAdmin();
        bool DeleteUser(string id);
        User GetUserById(int id);
        bool UpdateUser(string id, string name, string password);
        bool UpdateUserByAdmin(string id, string name, string password, string role);
        User SignIn(string name, string password);
    }
}