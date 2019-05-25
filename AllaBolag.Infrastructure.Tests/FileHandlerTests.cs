using System;
using System.IO;
using System.Collections.Generic;
using AllaBolag.Infrastructure.FileHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AllaBolag.Infrastructure.Tests
{
    [TestClass]
    public class FileHandlerTests
    {
        [TestMethod]
        public void FileReader_Returns_IEnumerable_Of_Company_Names()
        {
            //Arrange
            var handler = new FileReader();
            var expected = new List<string> { "Atea","Luthman"};
            var path = $"{Environment.CurrentDirectory}\\Companies.csv";

            //Act
            var actual = handler.ReadAllRows(path) as List<string>;
            //Assert
            Assert.AreEqual(expected.Count > 1, actual.Count > 1);
        }

    }
}
