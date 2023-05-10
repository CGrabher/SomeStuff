using ArrayList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListTests
{
    internal class LinkedListTests
    {
        public MyLinkedList<int> GetTestList(int count)
        {
            MyLinkedList<int> testList = new MyLinkedList<int>();

            for (int i = 0; i < count; i++)
            {
                testList.Add(i);
            }
            return testList;
        }

        [Test]
        public void NewArrayListShouldBeEmpty()
        {
            // ARRANGE 
            var list = new MyArrayList<int>();

            // ACT 
            var count = list.Count;

            // ASSERT I expect 0 as a result
            Assert.That(count, Is.EqualTo(0));
        }

        [TestCase(1, 4)]
        [TestCase(2, 5)]
        [TestCase(3, 5)]
        public void ItShouldCountAddedElements(int element, int ListCount)
        {
            // ARRANGE 
            var testList = GetTestList(ListCount);
            // ACT 
            testList.Add(element);
            // ASSERT Count should be ListCount
            Assert.That(testList.Count, Is.EqualTo(ListCount + 1));
        }

        [Test]
        public void Add_Should_Work()
        {
            //ARRANGE
            var testList = new MyArrayList<int>();
            // ACT
            testList.Add(1);
            testList.Add(2);
            // ASSERT
            Assert.That(testList.Count, Is.EqualTo(2));
            Assert.That(testList[0], Is.EqualTo(1));
            Assert.That(testList[1], Is.EqualTo(2));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        public void Index_Get_ReturnsRightValues(int index, int element)
        {
            // ARRANGE 
            var testList = GetTestList(5);

            // ACT & ASSERT should return them in the same order
            Assert.That(testList[index], Is.EqualTo(element));
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(3)]
        public void Index_Set_SetsRightValues(int index)
        {
            // ARRANGE 
            var testList = GetTestList(5);

            testList[index] = 42;

            // ACT & ASSERT should return them in the same order
            Assert.That(testList[index], Is.EqualTo(42));
        }

        [Test]
        public void ItShouldRemoveElementAtTheGivenIndex()
        {
            //ARRANGE 
            var testList = GetTestList(5);

            //ACT 
            testList.RemoveAt(3);

            //ASSERT the array should look like 0,1,2,4
            var expected = new int[] { 0, 1, 2, 4 };
            for (int i = 0; i < testList.Count(); i++)
            {
                //Assert.IsTrue(expected.SequenceEqual(testList)); //would work if we would implement IEnumerable

                //testList.Get(i) == expected[i];
                Assert.That(testList[i], Is.EqualTo(expected[i]));
            }
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(4)]
        public void Remove_ShouldDecreaseTheCount(int index)
        {
            //ARRANGE 
            var testList = GetTestList(5);

            //ACT 
            testList.RemoveAt(index);

            //ASSERT the count should be 1 less
            Assert.That(testList.Count, Is.EqualTo(4));
        }

        [TestCase(42, false)]
        [TestCase(0, true)]
        [TestCase(4, true)]
        [TestCase(-99, false)]
        public void Contains_Works(int value, bool expected)
        {
            //ARRANGE 
            var testList = GetTestList(5);

            //ACT 
            var result = testList.Contains(value);

            //ASSERT i should get a true back
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Clear_ShouldGiveAnEmptyArrayBack()
        {
            //ARRANGE 
            var testList = GetTestList(5);

            //ACT 
            testList.Clear();

            //ASSERT i should get back the empty List BUT with the LENGTH before
            Assert.That(testList.Count, Is.EqualTo(0));
        }

        [Test]
        public void Insert_ShouldGiveBackAnArrayWithTheInsertedElementWithin()
        {
            //ARRANGE 
            var testList = GetTestList(5);

            //ACT 
            testList.Insert(2, 9);

            //ASSERT the array Length should be increased by 1;
            Assert.That(testList.Count, Is.EqualTo(6));
            Assert.That(testList[2], Is.EqualTo(9));
        }

        [TestCase(-1)]
        [TestCase(5)]
        public void Insert_OutOfRange_ShouldThrowException(int index)
        {
            var testList = GetTestList(5);

            Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(index, 1));
            // Throw Exception when an index less than 0 is passed.
        }

        [Test]
        public void Insert_ShouldGetAnArrayWithTheInsertedElementAtTheCorrectPosition()
        {
            //ARRANGE 
            var testList = GetTestList(5);

            //ACT 
            testList.Insert(2, 9);

            //ASSERT the element at the position has to be the one i inserted
            Assert.That(testList[2], Is.EqualTo(9));
        }

        [Test]
        public void Remove_ShouldRemoveTheCorrectElement()
        {
            //ARRANGE 
            var testList = GetTestList(5);
            //0 1 2 3
            //ACT 
            testList.Remove(3);

            //ASSERT the testList should be decrased by 1;
            Assert.That(testList.Count, Is.EqualTo(4));
        }

        [TestCase(0)]
        [TestCase(3)]
        public void RemoveAt_ShouldRemoveTheCorrectElement(int index)
        {
            //ARRANGE
            var testList = GetTestList(5);
            //ACT & ASSERT
            testList.RemoveAt(index);
            
        }

        [Test]
        public void Swap_TwoElementsShouldSwapTheCorrectElements()
        {
            //ARRANGE 
            var testList = GetTestList(5);

            //ACT 
            testList.Swap(0, 1);

            //ASSERT Element A should be on the Position of Element B and inverted
            Assert.That(testList.Get(1), Is.EqualTo(0));
            Assert.That(testList.Get(0), Is.EqualTo(1));
        }

        [TestCase(-1, 2)]
        [TestCase(5, 2)]

        [TestCase(2, -1)]
        [TestCase(2, 5)]

        [TestCase(-1, 5)]
        [TestCase(5, -1)]
        public void Swap_OutOfRange_ShouldThrowException(int indexA, int indexB)
        {
            //ACT
            var testList = GetTestList(5);

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.Swap(indexA, indexB));
            //Throw Exception when an index less than 0 is passed.
        }

        [TestCase(0)]
        [TestCase(4)]
        [TestCase(3)]

        public void GetNodeAt_ShouldGiveTheCorrectNode(int index)
        {
            var testList = GetTestList(5);

            testList.GetElementAt(index);
        }

        [TestCase(-1)]
        [TestCase(6)]
        public void GetNodeAt_ShouldThrowException(int index)
        {
            //ARRANGE
            var testList = GetTestList(5);

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.GetElementAt(index));
        }

        [TestCase(0)]
        [TestCase(4)]
        public void ToString_ShouldGiveBackAString(int index)
        {
            //ARRANGE
            var testList = GetTestList(5);

            //ACT
            var result = testList[index].ToString();

            //ASSERT
            Assert.IsInstanceOf(typeof(string), result);
        }

        [TestCase(-1)]
        [TestCase(6)]
        public void ToString_ShouldThrowException(int index)
        {
            //ARRANGE
            var testList = GetTestList(5);

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => testList[index].ToString());
        }

        [Test]
        public void Count_ShouldWork()
        {
            //ARRANGE
            var testList = GetTestList(5);

            //ACT
            var testCount = testList.Count();

            //ASSERT
            Assert.That(testCount, Is.EqualTo(5));
        }

        [TestCase(0)]
        [TestCase(4)]
        public void Get_ShouldWork(int index)
        {
            //ARRANGE
            var testList = GetTestList(5);

            //ACT & ASSERT
            testList.Get(index);
        }

        [TestCase(-1)]
        [TestCase(6)]
        public void Get_ShouldThrowException(int index)
        {
            //ARRANGE
            var testList = GetTestList(5);

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.Get(index));
        }

    }
}
