using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RomanToInt.RomanNumber.Tests
{
    [TestClass()]
    public class RomanTests
    {
        [TestMethod()]
        public void RomanTest()
        {
            //arrange
            string expected = "XX";

            //act
            Roman roman = new Roman("xx");
            string actual = roman.Number;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RomanToIntTest()
        {
            int expected = 3999;

            //act
            Roman roman = new Roman("mmmcmxcix");
            int actual = roman.RomanToInt();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InputIsNotRomanNumberTest()
        {
            //arrange
            string expected = "Is not a Roman number ( I=1 V=5 X=10 L=50 C=100 D=500 M=1000 )";

            //act
            string actual = null;
            try
            {
                Roman roman = new Roman("H");
            }
            catch(Exception ex)
            {
                actual = ex.Message;
            }            

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InputOfAnIncorrectOrderOfRomanNumebersTest()
        {
            //arrange
            string expected = "Invalid order";

            //act
            string actual = null;
            try
            {
                int roman_to_int = new Roman("ivi").RomanToInt();

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