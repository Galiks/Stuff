using Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithFile.BLL.Interface;

namespace WorkWithFile
{
    class Program
    {
        private static IUserLogic userLogic;
        private static IFileLogic fileLogic;
        private static ICommentLogic commentLogic;

        static void Main(string[] args)
        {
            NinjectCommon.Ninject.Registration();

            userLogic = NinjectCommon.Ninject.Kernel.Get<IUserLogic>();
            fileLogic = NinjectCommon.Ninject.Kernel.Get<IFileLogic>();
            commentLogic = NinjectCommon.Ninject.Kernel.Get<ICommentLogic>();

            SignIn();
        }

        private static void SignIn()
        {
            while (true)
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
        }

        private static void UserMethod(User user)
        {
            UserMethodHepl();

            while (true)
            {
                var action = Console.ReadKey();

                switch (action.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        Console.Write("Enter File's Name: ");
                        var name_1 = Console.ReadLine();
                        Console.Write("Enter File's Text: ");
                        var text_1 = Console.ReadLine();
                        fileLogic.CreateFile(user.Id, name_1, text_1);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_2 = Console.ReadLine();
                        Console.Write("Enter File's TEXT");
                        var text_2 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateText(id_2, text_2);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Choose file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.Write("Enter File's ID");
                        var id_3 = Console.ReadLine();
                        Console.Write("Enter File's MARK");
                        var mark_3 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateMark(id_3, mark_3);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Choose file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.Write("Enter File's ID");
                        var id_4 = Console.ReadLine();
                        Console.Write("Enter Commit");
                        var commit_4 = Console.ReadLine();
                        Console.WriteLine();
                        commentLogic.CreateComment(id_4, commit_4);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D5:
                        var result_5 = userLogic.GetUserById(user.Id);
                        Console.WriteLine($"ID: {result_5.Id}{Environment.NewLine}Name: {result_5.Name}{Environment.NewLine}Password: {result_5.Password}{Environment.NewLine}Role: {result_5.Role}{Environment.NewLine}");
                        break;
                    case ConsoleKey.D6:
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_7 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.Delete(id_7);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("Chose file: ");
                        Console.WriteLine("Enter File's ID: ");
                        var id_0 = Console.ReadLine();
                        foreach (var item in commentLogic.ReadCommentByFile(id_0))
                        {
                            Console.WriteLine($"ID: {item.Id}{Environment.NewLine}Comment: {item.Commenting}{Environment.NewLine}");
                        }
                        Console.WriteLine();
                        break;
                    case ConsoleKey.Help:
                        UserMethodHepl();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void UserMethodHepl()
        {
            Console.WriteLine("You're USER and you can:");
            Console.WriteLine("Create file. Press 1");
            Console.WriteLine("Update only your file. Press 2");
            Console.WriteLine("Estimate file. Press 3");
            Console.WriteLine("Comment file. Press 4");
            Console.WriteLine("See information about you. Press 5");
            Console.WriteLine("See your files. Press 6");
            Console.WriteLine("Delete only your file. Press 7");
            Console.WriteLine("See file's comment. Press 0");
            Console.WriteLine("If you forget that you can. Press Hepl");
            Console.WriteLine("Do you wanna exit? Press Esc");
        }

        private static void ModeratorMethod(User user)
        {
            ModeratorMethodHelp();

            while (true)
            {
                var action = Console.ReadKey();

                switch (action.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        Console.Write("Enter File's Name: ");
                        var name_1 = Console.ReadLine();
                        Console.Write("Enter File's Text: ");
                        var text_1 = Console.ReadLine();
                        fileLogic.CreateFile(user.Id, name_1, text_1);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_2 = Console.ReadLine();
                        Console.Write("Enter File's TEXT");
                        var text_2 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateText(id_2, text_2);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Choose file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.Write("Enter File's ID");
                        var id_3 = Console.ReadLine();
                        Console.Write("Enter File's MARK");
                        var mark_3 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateMark(id_3, mark_3);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Choose file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.Write("Enter File's ID");
                        var id_4 = Console.ReadLine();
                        Console.Write("Enter Commit");
                        var commit_4 = Console.ReadLine();
                        Console.WriteLine();
                        commentLogic.CreateComment(id_4, commit_4);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D5:
                        var result_5 = userLogic.GetUserById(user.Id);
                        Console.WriteLine($"ID: {result_5.Id}{Environment.NewLine}Name: {result_5.Name}{Environment.NewLine}Password: {result_5.Password}{Environment.NewLine}Role: {result_5.Role}{Environment.NewLine}");
                        break;
                    case ConsoleKey.D6:
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_7 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.Delete(id_7);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D8:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_8 = Console.ReadLine();
                        Console.Write("Enter File's TEXT");
                        var text_8 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateTextByAdmin(id_8, text_8);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("Chose file: ");
                        Console.WriteLine("Enter File's ID: ");
                        var id_0 = Console.ReadLine();
                        foreach (var item in commentLogic.ReadCommentByFile(id_0))
                        {
                            Console.WriteLine($"ID: {item.Id}{Environment.NewLine}Comment: {item.Commenting}{Environment.NewLine}");
                        }
                        Console.WriteLine();
                        break;
                    case ConsoleKey.Help:
                        ModeratorMethodHelp();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ModeratorMethodHelp()
        {
            Console.WriteLine("You're MODERATOR and you can:");
            Console.WriteLine("Create file. Press 1");
            Console.WriteLine("Update only your file. Press 2");
            Console.WriteLine("Estimate file. Press 3");
            Console.WriteLine("Comment file. Press 4");
            Console.WriteLine("See information about you. Press 5");
            Console.WriteLine("See your files. Press 6");
            Console.WriteLine("Delete only your file. Press 7");
            Console.WriteLine("Update file. Press 8");
            Console.WriteLine("See file's comment. Press 0");
            Console.WriteLine("If you forget that you can. Press Help");
            Console.WriteLine("Do you wanna exit? Press Esc");
        }

        private static void AdminMethod(User user)
        {
            AdminMethodHelp();

            while (true)
            {
                var action = Console.ReadKey();

                switch (action.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        Console.Write("Enter File's Name: ");
                        var name_1 = Console.ReadLine();
                        Console.Write("Enter File's Text: ");
                        var text_1 = Console.ReadLine();
                        fileLogic.CreateFile(user.Id, name_1, text_1);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_2 = Console.ReadLine();
                        Console.Write("Enter File's TEXT");
                        var text_2 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateText(id_2, text_2);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Choose file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.Write("Enter File's ID");
                        var id_3 = Console.ReadLine();
                        Console.Write("Enter File's MARK");
                        var mark_3 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateMark(id_3, mark_3);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Choose file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.Write("Enter File's ID");
                        var id_4 = Console.ReadLine();
                        Console.Write("Enter Commit");
                        var commit_4 = Console.ReadLine();
                        Console.WriteLine();
                        commentLogic.CreateComment(id_4, commit_4);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D5:
                        var result_5 = userLogic.GetUserById(user.Id);
                        Console.WriteLine($"ID: {result_5.Id}{Environment.NewLine}Name: {result_5.Name}{Environment.NewLine}Password: {result_5.Password}{Environment.NewLine}Role: {result_5.Role}{Environment.NewLine}");
                        break;
                    case ConsoleKey.D6:
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFilesByUser(user.Id.ToString()))
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_7 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.Delete(id_7);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D8:
                        Console.WriteLine("Choose your file: ");
                        Console.WriteLine();
                        foreach (var item in fileLogic.ReadFiles())
                        {
                            Console.WriteLine($"{item.ID} : {item.Name}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter File's ID");
                        var id_8 = Console.ReadLine();
                        Console.Write("Enter File's TEXT");
                        var text_8 = Console.ReadLine();
                        Console.WriteLine();
                        fileLogic.UpdateTextByAdmin(id_8, text_8);
                        Console.WriteLine();
                        break;
                    case ConsoleKey.D9:
                        foreach (var item in userLogic.ReadUsers())
                        {
                            Console.WriteLine($"ID: {item.Id}{Environment.NewLine}Name: {item.Name}{Environment.NewLine}Password: {item.Password}{Environment.NewLine}Role: {item.Role}{Environment.NewLine}");
                        }
                        Console.WriteLine("Choose user");
                        Console.Write("User's ID: ");
                        var id_9 = Console.ReadLine();
                        Console.Write("New User's Role: ");
                        var role_9 = Console.ReadLine();
                        userLogic.UpdateUserById(id_9, role_9);
                        break;
                    case ConsoleKey.Help:
                        ModeratorMethodHelp();
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("Chose file: ");
                        Console.WriteLine("Enter File's ID: ");
                        var id_0 = Console.ReadLine();
                        foreach (var item in commentLogic.ReadCommentByFile(id_0))
                        {
                            Console.WriteLine($"ID: {item.Id}{Environment.NewLine}Comment: {item.Commenting}{Environment.NewLine}");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void AdminMethodHelp()
        {
            Console.WriteLine("You're MODERATOR and you can:");
            Console.WriteLine("Create file. Press 1");
            Console.WriteLine("Update only your file. Press 2");
            Console.WriteLine("Estimate file. Press 3");
            Console.WriteLine("Comment file. Press 4");
            Console.WriteLine("See information about you. Press 5");
            Console.WriteLine("See your files. Press 6");
            Console.WriteLine("Delete only your file. Press 7");
            Console.WriteLine("Update file. Press 8");
            Console.WriteLine("Update role. Press 9");
            Console.WriteLine("See file's comment. Press 0");
            Console.WriteLine("If you forget that you can. Press Help");
            Console.WriteLine("Do you wanna exit? Press Esc");
        }
    }
}
