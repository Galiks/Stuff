using System;
using System.Collections.Generic;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using WorkWithFile.BLL.Interface;

namespace WorkWithFile.Test
{
    [TestClass]
    public class CommentLogicTest
    {
        private ICommentLogic commentLogic;

        [TestMethod]
        public void CreateComment()
        {
            NinjectCommon.Ninject.Registration();

            commentLogic = NinjectCommon.Ninject.Kernel.Get<ICommentLogic>();

            var result = commentLogic.CreateComment("1", "qwe");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReadComment()
        {
            NinjectCommon.Ninject.Registration();

            commentLogic = NinjectCommon.Ninject.Kernel.Get<ICommentLogic>();

            var result = commentLogic.ReadCommentByFile("1");

            Assert.IsInstanceOfType(result, typeof(List<Comment>));
        }
    }
}
