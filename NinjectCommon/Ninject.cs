using Blogs.BLL.Logic;
using Blogs.DAL.DAO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            _kernel.Bind<IBlogDao>().To<BlogDao>();
            _kernel.Bind<IBlogLogic>().To<BlogLogic>();
        }
    }
}
