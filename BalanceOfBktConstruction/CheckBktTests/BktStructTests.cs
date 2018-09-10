using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CheckBkt.Tests
{
    [TestClass()]
    public class BktStructTests
    {
        [TestMethod()]
        public void CheckTest()
        {
            //arrange
            string expected = "Cкобочная последовательность корректна";

            //act
            string actual = BktStruct.Check("{()[]()}");

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void СheckTheExpressionWithClosingBracketTest()
        {
            //arrange
            string expected = "Структура не может начинаться с закрывающей скобки - \"}\"";

            //act
            string actual = null;
            try
            {
                BktStruct.Check("}{()[]()}");
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }
            
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void СheckTheExpressionWithNonClosedPrevBracketTest()
        {
            //arrange
            string expected = "Предыдущая скобка не закрыта - \"(\"";

            //act
            string actual = null;
            try
            {
                BktStruct.Check("{(})[]()}");
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void СheckTheExpressionWithNonClosedBracketыTest()
        {
            //arrange
            string expected = "Последовательность содержит не закрытые скобки - { { ";

            //act
            string actual = null;
            try
            {
                BktStruct.Check("()[](){{");
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckExpressionWithoutBracketsTest()
        {
            //arrange
            string expected = "Выражение не содержит скобок";

            //act
            string actual = null;
            try
            {
                BktStruct.Check("1+1");
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}