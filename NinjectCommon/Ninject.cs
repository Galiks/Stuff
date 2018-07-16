using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithFile.BLL.Interface;
using WorkWithFile.BLL.Logic;
using WorkWithFile.DAL.DAO;

namespace NinjectCommon
{
    public static class Ninject
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<IUserDao>().To<UserDao>();
            _kernel.Bind<IUserLogic>().To<UserLogic>();

            _kernel.Bind<IFileDao>().To<FileDao>();
            _kernel.Bind<IFileLogic>().To<FileLogic>();

            _kernel.Bind<ICommentDao>().To<CommentDao>();
            _kernel.Bind<ICommentLogic>().To<CommentLogic>();
        }
    }
}
