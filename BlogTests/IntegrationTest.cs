using System;
using System.Collections.Generic;
using Blogs.BLL.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace BlogTests
{
    [TestClass]
    public class IntegrationTest
    {
        private IBlogLogic blogLogic;


        [TestMethod]
        public void CreateBlog()
        {

            NinjectCommon.Ninject.Registration();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();
            var result = blogLogic.CreateBlog("1", "Animal", "Tiger, Lion, Elephant");

            Assert.IsTrue(result, "False");
        }

        [TestMethod]
        public void ReadBlogs()
        {

            NinjectCommon.Ninject.Registration();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();
            var result = blogLogic.ReadBlogs();

            Assert.IsInstanceOfType(result, typeof(List<Blog.Models.Blog>));
        }

        [TestMethod]
        public void GetBlogById()
        {
            NinjectCommon.Ninject.Registration();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();
            var result = blogLogic.GetBlogById(2);

            Assert.IsNotNull(result, "NULL");
            Assert.IsInstanceOfType(result, typeof(Blog.Models.Blog), "ERROR");
        }

        [TestMethod]
        public void DeleteBlog()
        {
            NinjectCommon.Ninject.Registration();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();
            var result = blogLogic.DeleteBlog("1");

            Assert.IsTrue(result, "False");
        }

        [TestMethod]
        public void UpdateBlog()
        {
            NinjectCommon.Ninject.Registration();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();
            var result = blogLogic.UpdateBlog("2", "5");

            Assert.IsTrue(result, "False");
        }

        [TestMethod]
        public void UpdateBlogByAdmin()
        {
            NinjectCommon.Ninject.Registration();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();
            var result = blogLogic.UpdateBlogByAdmin("2", "Animal", "Tiger, Lion, Elephant", "8");

            Assert.IsTrue(result, "False");
        }

        [TestMethod]
        public void GetBlogsByUser()
        {
            NinjectCommon.Ninject.Registration();
            blogLogic = NinjectCommon.Ninject.Kernel.Get<IBlogLogic>();
            var result = blogLogic.GetBlogsByUser("1");

            Assert.IsInstanceOfType(result, typeof(List<Blog.Models.Blog>));
        }

    }
}
