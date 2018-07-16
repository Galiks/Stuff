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
    public class FileLogicTest
    {
        [TestMethod]
        public void CreateFile()
        {
            var mock = new Mock<IFileDao>();

            mock.Setup(item => item.CreateFile(1, "qwe", "123")).Returns(100);

            var logic = new FileLogic(mock.Object);

            Assert.IsTrue(logic.CreateFile(1, "qwe", "qwe"));
        }

        [TestMethod]
        public void DeleteFile()
        {
            var mock = new Mock<IFileDao>();

            mock.Setup(item => item.DeleteFile(1)).Returns(100);

            var logic = new FileLogic(mock.Object);

            Assert.IsInstanceOfType(logic.Delete("1"), typeof(bool));
        }

        [TestMethod]
        public void GetFileById()
        {
            var mock = new Mock<IFileDao>();

            mock.Setup(item => item.GetFileById(1)).Returns(new Files());

            var logic = new FileLogic(mock.Object);

            Assert.IsInstanceOfType(logic.GetFileById(1), typeof(Files));
        }

        [TestMethod]
        public void ReadFiles()
        {
            var mock = new Mock<IFileDao>();

            mock.Setup(item => item.ReadFiles()).Returns(new List<Files>());

            var logic = new FileLogic(mock.Object);

            Assert.IsInstanceOfType(logic.ReadFiles(), typeof(List<Files>));
        }

        [TestMethod]
        public void ReadFilesByUser()
        {
            var mock = new Mock<IFileDao>();

            mock.Setup(item => item.ReadFilesByUser(1)).Returns(new List<Files>());

            var logic = new FileLogic(mock.Object);

            Assert.IsInstanceOfType(logic.ReadFiles(), typeof(List<Files>));
        }

        [TestMethod]
        public void UpdateMark()
        {
            var mock = new Mock<IFileDao>();

            mock.Setup(item => item.UpdateMark(1, 3)).Returns(100);

            var logic = new FileLogic(mock.Object);

            Assert.IsFalse(logic.UpdateMark("1", "3"));
        }

        [TestMethod]
        public void UpdateText()
        {
            var mock = new Mock<IFileDao>();

            mock.Setup(item => item.UpdateText(1, "qwe")).Returns(100);

            var logic = new FileLogic(mock.Object);

            Assert.IsNotNull(logic.GetFileById(2));

            Assert.IsFalse(logic.UpdateMark("1", "3"));
        }
    }
}
