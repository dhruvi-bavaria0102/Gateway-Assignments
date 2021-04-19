using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using BasicFunctionalityConsoleApp;
using System.Threading.Tasks;
using System;

namespace BasicFunctionalityConsoleApp.Tests
{
   
    public class BasicOperationsTests
    {
        // Create object of BasicOperations class
        private BasicOperations _basicOperations;

        [SetUp]
        public void Setup()
        {
            _basicOperations = new BasicOperations();
        }
        #region Async Testing
        [Test]
        public async Task TestAddition_Async()
        {
            // Act
            var result = await _basicOperations.Addition(10, 5);
            // Assert
            Assert.AreEqual(15, result);
        }

        [Test(ExpectedResult = 15)]
        public async Task<int> TestAddition_Async_without_Assert()
        {
            return await _basicOperations.Addition(10, 5);
        }
        #endregion

        #region Different Loop Testing
        // while loop test case
        [TestCase(-1, 10)]
        [TestCase(0, 10)]
        [TestCase(1, 10)]
        public void Add_whileLoop(int value, int expected)
        {
            // Act
            var result = _basicOperations.Add(value);
            // Assert
            Assert.AreEqual(expected, result);
        }

        // for loop test case     
        [TestCase(0, 25)]
        [TestCase(5, 30)]
        public void Subtract10_Test(int value, int expected)
        {
            // Act
            var result = _basicOperations.IncreamentNumberBy5(value);
            // Assert
            Assert.AreEqual(expected, result);
        }

        // foreach loop test case       
        [TestCaseSource(typeof(EvenNumberListClass), nameof(EvenNumberListClass.TestCases))]
        public int FindOddNumbers_Test(List<int> values)
        {
            // Act
            var result = _basicOperations.FindEvenNumbers(values);

            return result;
        }

        // Switch case test cases
        [Test]
        public void CheckString_Return_UppercaseString()
        {
            // Act
            var result = _basicOperations.CheckString("hello", 1);
            // Assert
            Assert.AreEqual("HELLO", result);
        }
        [Test]
        public void CheckString_Return_LowercaseString()
        {
            // Act
            var result = _basicOperations.CheckString("HELLO", 2);
            // Assert
            Assert.AreEqual("hello", result);
        }
        [Test]
        public void CheckString_Return_InvalidOperation()
        {
            // Act
            var result = _basicOperations.CheckString("HeLlO", 4);
            // Assert
            Assert.AreEqual("Invalid operation.", result);
        }

        #endregion

        #region Exception Handling Test Cases
        // If-else condition and Argument Null Exception test case
        [Test]
        public void TestLogin_Return_Login_Successful()
        {
            // Act
            string result = _basicOperations.Login("Dhruvi", "Dhruvi@0102");
            // Assert
            Assert.AreEqual("Success", result);
        }
        [Test]
        public void TestLogin_Return_ArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _basicOperations.Login("",""));
        }

        // Exception test cases
        [Test]
        public void DivideNumber_Return_Value()
        {
            // Act
            var result = _basicOperations.DivideNumber(10, 5);
            // Assert
            Assert.AreEqual(2, result);
        }
        [Test]
        public void DivideNumber_Should_Throw_DivideByZeroException()
        {
            // Assert
            Assert.Throws<DivideByZeroException>(() => _basicOperations.DivideNumber(10, 0));
        }
        #endregion
    }
    public class EvenNumberListClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<int> { 8 }).Returns(1);
                yield return new TestCaseData(new List<int> { 12, 4, 16, 8 }).Returns(4);
            }
        }
    }
}