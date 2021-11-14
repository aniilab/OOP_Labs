using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PseudoExcelExpressionCalculator;

namespace PseudoExcelExpressionCalculatorUnitTests
{
    [TestClass]
    public class CalculatorUnitTests
    {
        [TestMethod]
        public void Evaluate_DivisionByZero_ReturnInfinity()
        {
            //Arrange
            string expression = "10/0";
            string expectedResult = "∞";

            //Act
            string result = Calculator.Evaluate(expression);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
