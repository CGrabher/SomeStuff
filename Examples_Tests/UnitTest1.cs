using NUnit.Framework;
using Examples;
using System;
using System.Collections.Generic;

namespace Examples.Tests
{
    public class Collatz_ConjectureTests
    {
        private Collatz_Conjecture collatz;

        [SetUp]
        public void Setup()
        {
            collatz = new Collatz_Conjecture();
        }

        [Test]
        public void CollatzSequence_ReturnsCorrectSequence_ForEvenNumber()
        {
            // Arrange
            int num = 10;
            List<int> expectedSequence = new List<int> { 10, 5, 16, 8, 4, 2, 1 };

            // Act
            List<int> result = collatz.CollatzSequence(num);

            // Assert 
            CollectionAssert.AreEqual(expectedSequence, result);
        }

        [Test]
        public void CollatzSequence_ReturnsCorrectSequence_ForOddNumber()
        {
            // Arrange
            int num = 7;
            List<int> expectedSequence = new List<int> { 7, 22, 11, 34, 17, 52, 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };

            // Act
            List<int> result = collatz.CollatzSequence(num);

            // Assert
            CollectionAssert.AreEqual(expectedSequence, result);
        }

        [Test]
        public void CollatzSequence_ReturnsSequenceWithOnlyOneElement_ForNumberOne()
        {
            // Arrange
            int num = 1;
            List<int> expectedSequence = new List<int> { 1 };

            // Act
            List<int> result = collatz.CollatzSequence(num);

            // Assert
            CollectionAssert.AreEqual(expectedSequence, result);
        }

        [Test]
        public void CollatzSequence_ThrowsOverflowException_ForLargeNumber()
        {
            // Arrange
            int num = int.MaxValue;

            // Act and Assert
            Assert.Throws<OverflowException>(() => collatz.CollatzSequence(num));
        }
    }
}
