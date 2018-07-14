using System.Collections.Generic;
using Blog.Models;

namespace Blogs.DAL.DAO
{
    public interface IUserDao
    {
        int CreateUserbyAdmin(string name, string password, int role);
        int CreateUser(string name, string password);
        IEnumerable<User> ReadUsers();
        IEnumerable<User> ReadUsersByAdmin();
        int DeleteUser(int id);
        User GetUserById(int id);
        int UpdateUser(int id, string name, string password);
        int UpdateUserByAdmin(int id, string name, string password, int role);
    }
}