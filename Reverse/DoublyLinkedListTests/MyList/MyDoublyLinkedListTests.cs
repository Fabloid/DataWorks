using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedList.MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.MyList.Tests
{
    [TestClass()]
    public class MyDoublyLinkedListTests
    {
        [TestMethod()]
        public void AddFirstTest()
        {
            //arrange
            object expected = 4;

            //act
            MyDoublyLinkedList<object> list = new MyDoublyLinkedList<object>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(4);
            object actual = list.First();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddLastTest()
        {
            //arrange
            object expected = 4;

            //act
            MyDoublyLinkedList<object> list = new MyDoublyLinkedList<object>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            object actual = list.Last();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReverseTest()
        {
            //arrange
            object expected = 1;

            //act
            MyDoublyLinkedList<object> list = new MyDoublyLinkedList<object>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.Reverse();
            object actual = list.Last();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}