using Microsoft.VisualStudio.TestTools.UnitTesting;
using PseudoExcel.Entities;

namespace PseudoExcelUnitTests
{
    [TestClass]
    public class TableUnitTests
    {
        [TestMethod]
        public void Calculate_WrongExpression_ReturnError()
        {
            //Arrange
            string expression = "a+b";
            string expectedResult = "error";
            Table table = new Table(10,10);

            //Act
            string result = table.Calculate(expression);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
