using System.Collections.Generic;
using Entity;

namespace WorkWithFile.DAL.DAO
{
    public interface IUserDao
    {
        int CreateUser(string name, string password);
        int CreateUserByAdmin(string name, string password, int role);
        int DeleteUser(int id);
        User GetUserById(int id);
        IEnumerable<User> ReadUsers();
        int UpdateUser(int id, string name, string password);
        int UpdateUserById(int id, int role);
    }
}