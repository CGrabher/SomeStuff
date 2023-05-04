using ArrayList;
using NuGet.Frameworks;
using NUnit.Framework;
using System.Collections.Generic;

namespace ArrayListTests;

public class ArrayListTests
{
    public MyArrayList<int> GetTestList(int count)
    {
        MyArrayList<int> testList = new MyArrayList<int>();

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

    [Test]
    public void ItShouldCountAddedElements()
    {
        // ARRANGE 
        var testList = new MyArrayList<int>();
        // ACT 
        testList.Add(1);
        testList.Add(2);
        testList.Add(3);
        testList.Add(4);
        // ASSERT count should be 3
        Assert.That(testList.Count, Is.EqualTo(4));
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

    [Test]
    public void Index_Get_ReturnsRightValues()
    {
        // ARRANGE 
        var testList = GetTestList(4);

        // ACT & ASSERT should return them in the same order
        Assert.That(testList[0], Is.EqualTo(0));
        Assert.That(testList[1], Is.EqualTo(1));
        Assert.That(testList[2], Is.EqualTo(2));
        Assert.That(testList[3], Is.EqualTo(3));
    }

    [TestCase(0)]
    [TestCase(2)]
    [TestCase(3)]
    public void Index_Set_SetsRightValues(int index)
    {
        // ARRANGE 
        var testList = GetTestList(4);

        testList[index] = 42;

        // ACT & ASSERT should return them in the same order
        Assert.That(testList[index], Is.EqualTo(42));
    }

    [Test]
    public void ItShouldRemoveElementAtTheGivenIndex()
    {
        //ARRANGE 
        var testList = GetTestList(4);


        //ACT 
        testList.RemoveAt(3);

        //ASSERT the array should look like 0,1,2,4
        var expected = new int[] { 0, 1, 2, 4 };
        for (int i = 0; i < testList.Count; i++)
        {
            //Assert.IsTrue(expected.SequenceEqual(testList)); //would work if we would implement IEnumerable

            //testList.Get(i) == expected[i];
            Assert.That(testList[i], Is.EqualTo(expected[i]));
        }
    }

    [TestCase(0)]
    [TestCase(2)]
    [TestCase(4)]
    public void RemovingShouldDecreaseTheCount(int index)
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
    public void ClearShouldGiveAnEmptyArrayBack()
    {
        //ARRANGE 
        var testList = GetTestList(4);

        //ACT 
        testList.Clear();

        //ASSERT i should get back the empty List BUT with the LENGTH before
        Assert.That(testList.Count, Is.EqualTo(0));
    }

    [Test]
    public void InsertShouldGiveBackAnArrayWithTheInsertedElementWithin()
    {
        //ARRANGE 
        var testList = GetTestList(4);

        //ACT 
        testList.Insert(2, 9);

        //ASSERT the array Length should be increased by 1;
        Assert.That(testList.Count, Is.EqualTo(5));
        Assert.That(testList[2], Is.EqualTo(9));
    }

    [TestCase(-1)]
    [TestCase(5)]
    public void InsertOutOfRange_ShouldThrowException(int index)
    {
        var testList = GetTestList(5);

        Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(index, 1));
        // Throw Exception when an index less than 0 is passed.
    }

    [Test]
    public void InsertShouldGetAnArrayWithTheInsertedElementAtTheCorrectPosition()
    {
        //ARRANGE 
        var testList = GetTestList(4);

        //ACT 
        testList.Insert(2, 9);

        //ASSERT the element at the position has to be the one i inserted
        Assert.That(testList[2], Is.EqualTo(9));
    }

    [Test]

    public void RemoveShouldRemoveTheCorrectElement()
    {
        //ARRANGE 
        var testList = GetTestList(4);

        //ACT 
        testList.Remove(2);

        //ASSERT the testList should no longer contain the element
        Assert.That(testList[2], Is.EqualTo(3));

        //ASSERT the testList should be decrased by 1;
        Assert.That(testList.Count, Is.EqualTo(3));
    }

    [Test]
    public void SwapTwoElementsShouldSwapTheCorrectElements()
    {
        //ARRANGE 
        var testList = GetTestList(4);

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

    public void SwapOutOfRange_ShouldThrowException(int indexA, int indexB)
    {
        var testList = GetTestList(5);

        Assert.Throws<ArgumentOutOfRangeException>(() => testList.Swap(indexA, indexB));
        // Throw Exception when an index less than 0 is passed.
    }

    //[Test]
    //public void TestEnsureIndexInRange()
    //{
    //    // ARRANGE
    //    var list = new MyArrayList<int>();

    //    // ACT and ASSERT
    //    Assert.Throws<ArgumentOutOfRangeException>(() => list.EnsureIndexInRange(-1));
    //    // Throw Exception when an index less than 0 is passed.

    //    Assert.Throws<ArgumentOutOfRangeException>(() => list.EnsureIndexInRange(0));
    //    // Throw Exception when the index is 0, since indexing starts at 0.

    //    list.Add(1);
    //    Assert.Throws<ArgumentOutOfRangeException>(() => list.EnsureIndexInRange(1));
    //    // Throw Exception when an index greater than the index of the last element in the list is passed.

    //    // Not throw an exception when valid indices are passed.
    //    Assert.DoesNotThrow(() => list.EnsureIndexInRange(0));

    //}

   
   
   
   
   
   
   
   
   
   
   
}  