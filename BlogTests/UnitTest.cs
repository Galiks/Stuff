using System;
using System.Collections.Generic;
using Blog.Models;
using Blogs.BLL.Logic;
using Blogs.DAL.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlogTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CreateUserByAdmin()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.CreateUserbyAdmin("Ivan", "123", 0)).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.AreEqual(logic.CreateUserByAdmin("Ivan", "123", 3), true, "NOT EQUAL");
        }

        [TestMethod]
        public void CreateUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.CreateUser("Ivan", "123")).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsTrue(logic.CreateUser("Ivan", "123"), "FALSE");
        }

        [TestMethod]
        public void ReadUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.ReadUsers()).Returns(new List<User>() { new User() });

            var logic = new UserLogic(mock.Object);

            Assert.IsNotNull(logic.ReadUsers(), "NULL");
        }

        [TestMethod]
        public void ReadUserByAdmin()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.ReadUsersByAdmin()).Returns(new List<User>() { new User() });

            var logic = new UserLogic(mock.Object);

            Assert.IsNotNull(logic.ReadUsersByAdmin(), "NULL");
        }

        [TestMethod]
        public void DeleteUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.DeleteUser(1)).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsFalse(logic.DeleteUser("1"), "True");
        }

        [TestMethod]
        public void GetUserById()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.GetUserById(1)).Returns(new User());

            var logic = new UserLogic(mock.Object);

            Assert.IsInstanceOfType(logic.GetUserById(1), typeof(User), "ERROR");
        }

        [TestMethod]
        public void UpdateUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.UpdateUser(1, "Ivan", "123")).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsFalse(logic.UpdateUser("1", "Ivan", "123"), "True");
        }

        [TestMethod]
        public void UpdateUserByAdmin()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.UpdateUser(1, "Ivan", "123")).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsFalse(logic.UpdateUser("1", "Ivan", "123"), "True");
        }

    }
}
