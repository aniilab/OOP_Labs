using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PseudoExcel.Utils;

namespace PseudoExcelUnitTests
{
    [TestClass]
    public class Sys26UnitTests
    {
        [TestMethod]
        public void To26Sys_iEquals25_returnZ()
        {
            //Arrange
            int columnNumber = 25;
            string expectedResult = "Z";

            //Act
            string result = Sys26.To26Sys(columnNumber);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void From26Sys_sEqualsAA0_returnsCorrectRes()
        {
            //Arrange
            string cellName = "AA0";
            Index expectedResult = new Index { row_ = 0, col_ = 26 };

            //Act
            Index result = Sys26.From26Sys(cellName);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
