using System;
using System.Collections.Generic;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorkWithFile.BLL.Logic;
using WorkWithFile.DAL.DAO;

namespace WorkWithFile.Test
{
    [TestClass]
    public class UserLogicTest
    {
        [TestMethod]
        public void CreateUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.CreateUser("Sergei", "123")).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsTrue(logic.CreateUser("Sergei", "123"), "FALSE");
        }

        [TestMethod]
        public void CreateUserByAdmin()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.CreateUserByAdmin("Sergei", "123", 1)).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsTrue(logic.CreateUserByAdmin("Sergei", "123", "1"), "FALSE");
        }

        [TestMethod]
        public void DeleteUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.DeleteUser(1)).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsTrue(logic.DeleteUser("1"), "FALSE");
        }

        [TestMethod]
        public void GetUserById()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.GetUserById(1)).Returns(new User());

            var logic = new UserLogic(mock.Object);

            Assert.IsInstanceOfType(logic.GetUserById(1), typeof(User));
        }

        [TestMethod]
        public void ReadUsers()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.ReadUsers()).Returns(new List<User>());

            var logic = new UserLogic(mock.Object);

            Assert.IsInstanceOfType(logic.ReadUsers(), typeof(List<User>));
        }

        [TestMethod]
        public void UpdateUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.UpdateUser(1,"Pasha","321")).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.IsTrue(logic.UpdateUser("1", "Pasha", "321"));
        }

        [TestMethod]
        public void UpdateUserById()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.UpdateUserById(3, 2)).Returns(100);

            var logic = new UserLogic(mock.Object);

            Assert.AreEqual(logic.UpdateUserById("3", "2"), logic.UpdateUserById("2", "3"));
        }
    }
}
