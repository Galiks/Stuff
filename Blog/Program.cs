using Blog.Models;
using Blogs.BLL.Logic;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs
{
    class Program
    {
        private static IUserLogic userLogic;
        private static IBlogLogic blogLogic;

        static void Main(string[] args)
        {
            NinjectCommon.Ninject.Registration();

            userLogic = NinjectCommon.Ninject.Kernel.Get<IUserLogic>();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();

            SignIn();
        }

        private static void SignIn()
        {
            Console.WriteLine("Please, write your name and password");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            var user = userLogic.SignIn(name, password);
            if (user.Role == 1)
            {
                AdminMethod(user);
                return;
            }
            if (user.Role == 2)
            {
                ModeratorMethod(user);
                return;
            }
            if (user.Role == 3)
            {
                UserMethod(user);
                return;
            }
        }

        private static void ModeratorMethod(User user)
        {
            while (true)
            {
                Console.WriteLine("MODERATOR");
                Console.WriteLine("You can: ");
                Console.WriteLine("Update yourself - 1");
                Console.WriteLine("Create blog - 2");
                Console.WriteLine("Update blog - 3");
                Console.WriteLine("See information about you - 4");
                Console.WriteLine("Update blog how admin - 5");
                Console.WriteLine("See your blogs - 6");
                Console.WriteLine("If you wanna exit press Esc");

                var action = Console.ReadKey();

                switch (action.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.D1:
                        Console.Write("New Name: ");
                        var userName_1 = Console.ReadLine();
                        Console.Write("New Password: ");
                        var userPassword_1 = Console.ReadLine();
                        if (userLogic.UpdateUser(user.UserId.ToString(), userName_1, userPassword_1))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Write("Blog's Name: ");
                        var blogName_2 = Console.ReadLine();
                        Console.Write("Blog's Text: ");
                        var blogText_2 = Console.ReadLine();
                        if (blogLogic.CreateBlog(user.UserId.ToString(), blogName_2, blogText_2))
                        {
                            Console.WriteLine("Create Blog!");
                        }
                        else
                        {
                            Console.WriteLine("Can't create blog");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Write("Blog's ID: ");
                        var blogId_3 = Console.ReadLine();
                        Console.Write("Blog's Rating: ");
                        var blogRating_3 = Console.ReadLine();
                        if (blogLogic.UpdateBlog(blogId_3, blogRating_3))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine($"ID : {user.UserId}{Environment.NewLine}Name : {user.Name}{Environment.NewLine}Password : {user.Password}{Environment.NewLine}Role : {user.Role}{Environment.NewLine}");
                        break;
                    case ConsoleKey.D5:
                        Console.Write("Blog's ID: ");
                        var blogId_5 = Console.ReadLine();
                        Console.Write("Name: ");
                        var blogName_5 = Console.ReadLine();
                        Console.Write("Text: ");
                        var blogText_5 = Console.ReadLine();
                        Console.Write("Rating : ");
                        var blogRating_5 = Console.ReadLine();
                        if (blogLogic.UpdateBlogByAdmin(blogId_5, blogName_5, blogText_5, blogRating_5))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D6:
                        var result_5 = blogLogic.GetBlogsByUser(user.UserId.ToString());
                        if (result_5 != null)
                        {
                            foreach (var item in result_5)
                            {
                                Console.WriteLine($"ID : {item.BlogId}{Environment.NewLine}Name : {item.Name}{Environment.NewLine}Rating : {item.Rating}{Environment.NewLine}Text : {Environment.NewLine}{item.Text}{Environment.NewLine}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You haven't blogs");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void UserMethod(Blog.Models.User user)
        {
            while (true)
            {
                Console.WriteLine("USER");
                Console.WriteLine("You can: ");
                Console.WriteLine("Update yourself - 1");
                Console.WriteLine("Create blog - 2");
                Console.WriteLine("Update blog - 3");
                Console.WriteLine("See information about you - 4");
                Console.WriteLine("See your blogs - 5");
                Console.WriteLine("If you wanna exit press Esc");

                var action = Console.ReadKey();

                switch (action.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.D1:
                        Console.Write("New Name: ");
                        var userName_1 = Console.ReadLine();
                        Console.Write("New Password: ");
                        var userPassword_1 = Console.ReadLine();
                        if (userLogic.UpdateUser(user.UserId.ToString(), userName_1, userPassword_1))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Write("Blog's Name: ");
                        var blogName_2 = Console.ReadLine();
                        Console.Write("Blog's Text: ");
                        var blogText_2 = Console.ReadLine();
                        if (blogLogic.CreateBlog(user.UserId.ToString(), blogName_2, blogText_2))
                        {
                            Console.WriteLine("Create Blog!");
                        }
                        else
                        {
                            Console.WriteLine("Can't create blog");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Write("Blog's ID: ");
                        var blogId_3 = Console.ReadLine();
                        Console.Write("Blog's Rating: ");
                        var blogRating_3 = Console.ReadLine();
                        if (blogLogic.UpdateBlog(blogId_3, blogRating_3))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine($"ID : {user.UserId}{Environment.NewLine}Name : {user.Name}{Environment.NewLine}Password : {user.Password}{Environment.NewLine}Role : {user.Role}{Environment.NewLine}");
                        break;
                    case ConsoleKey.D5:
                        var result_5 = blogLogic.GetBlogsByUser(user.UserId.ToString());
                        if (result_5 != null)
                        {
                            foreach (var item in result_5)
                            {
                                Console.WriteLine($"ID : {item.BlogId}{Environment.NewLine}Name : {item.Name}{Environment.NewLine}Rating : {item.Rating}{Environment.NewLine}Text : {Environment.NewLine}{item.Text}{Environment.NewLine}");
                            } 
                        }
                        else
                        {
                            Console.WriteLine("You haven't blogs");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void AdminMethod(User user)
        {
            while (true)
            {
                Console.WriteLine("ADMIN");
                Console.WriteLine("You can: ");
                Console.WriteLine("Update all User (name, password, role) - 1");
                Console.WriteLine("Update User (name, password) - 2");
                Console.WriteLine("Delete User - 3");
                Console.WriteLine("Get all users with password - 4");
                Console.WriteLine("Update blog how admin - 5");
                Console.WriteLine("Delete blog - 6");
                Console.WriteLine("Get all blogs - 7");
                Console.WriteLine("Create blog - 8");
                Console.WriteLine("If you wanna exit press Esc");

                var action = Console.ReadKey(intercept: true);

                switch (action.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("User's ID: ");
                        var userId_1 = Console.ReadLine();
                        Console.Write("Name: ");
                        var userName_1 = Console.ReadLine();
                        Console.Write("Password: ");
                        var userPassword_1 = Console.ReadLine();
                        Console.Write("Role ( 1 - admin, 2 - moderator, 3 - user ) : ");
                        var userRole_1 = Console.ReadLine();
                        if (userLogic.UpdateUserByAdmin(userId_1, userName_1, userPassword_1, userRole_1))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Write("User's ID: ");
                        var userId_2 = Console.ReadLine();
                        Console.Write("Name: ");
                        var userName_2 = Console.ReadLine();
                        Console.Write("Password: ");
                        var userPassword_2 = Console.ReadLine();
                        if (userLogic.UpdateUser(userId_2, userName_2, userPassword_2))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Write("User's ID: ");
                        var userId_3 = Console.ReadLine();
                        if (userLogic.DeleteUser(userId_3))
                        {
                            Console.WriteLine("Delete ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't delete");
                        }
                        break;
                    case ConsoleKey.D4:
                        foreach (var item in userLogic.ReadUsersByAdmin())
                        {
                            Console.WriteLine($"ID : {item.UserId}{Environment.NewLine}Name : {item.Name}{Environment.NewLine}Password : {item.Password}{Environment.NewLine}Role : {item.Role}{Environment.NewLine}");
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.Write("Blog's ID: ");
                        var blogId_5 = Console.ReadLine();
                        Console.Write("Name: ");
                        var blogName_5 = Console.ReadLine();
                        Console.Write("Text: ");
                        var blogText_5 = Console.ReadLine();
                        Console.Write("Rating : ");
                        var blogRating_5 = Console.ReadLine();
                        if (blogLogic.UpdateBlogByAdmin(blogId_5, blogName_5, blogText_5, blogRating_5))
                        {
                            Console.WriteLine("Update ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't update");
                        }
                        break;
                    case ConsoleKey.D6:
                        Console.Write("Blog's ID: ");
                        var blogId_6 = Console.ReadLine();
                        if (blogLogic.DeleteBlog(blogId_6))
                        {
                            Console.WriteLine("Delete ready!");
                        }
                        else
                        {
                            Console.WriteLine("Can't delete");
                        }
                        break;
                    case ConsoleKey.D7:
                        var blogs = blogLogic.ReadBlogs();
                        if (blogs != null)
                        {
                            foreach (var item in blogs)
                            {
                                Console.WriteLine($"ID : {item.BlogId}{Environment.NewLine}Name : {item.Name}{Environment.NewLine}Rating : {item.Rating}{Environment.NewLine}Text : {Environment.NewLine}{item.Text}{Environment.NewLine}");
                            }
                        }
                        break;
                    case ConsoleKey.D8:
                        Console.Write("Blog's Name: ");
                        var blogName_2 = Console.ReadLine();
                        Console.Write("Blog's Text: ");
                        var blogText_2 = Console.ReadLine();
                        if (blogLogic.CreateBlog(user.UserId.ToString(), blogName_2, blogText_2))
                        {
                            Console.WriteLine("Create Blog!");
                        }
                        else
                        {
                            Console.WriteLine("Can't create blog");
                        }
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
