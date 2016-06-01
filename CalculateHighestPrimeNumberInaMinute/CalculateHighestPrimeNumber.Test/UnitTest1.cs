using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculateIsPrimeLib;


namespace CalculateHighestPrimeNumber.Test
{
    [TestClass]
    public class PrimeNumberTest
    {
        CalculateIsPrime cs;

        [TestInitialize]
        public void TestSetup()
        {
            cs = new CalculateIsPrime();
        }

        [TestMethod]
        public void ShouldReturnTrueForPrimeNumber()
        {
            int[] numberToTest = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            //Act
            for (var i = 0; i <numberToTest.Length;i++ )
            {
                //Assert
                Assert.IsTrue(cs.isPrimeNumber(numberToTest[i]));
            }

                
        }

        [TestMethod]
        public void ShouldReturnFalseForNonPrimeNumbers()
        {
            int[] numberToTest = { 4, 6, 9, 12, 15, 18, 20, 25, 28, 32 };
            //Act
            for (var i = 0; i < numberToTest.Length; i++)
            {
                //Assert
                Assert.IsFalse(cs.isPrimeNumber(numberToTest[i]));
            }
        }

        [TestMethod]
        public void ShouldThrowExpectionForNegativeAndZeroNumbers()
        {
            int[] numberToTest = { -4, -6, 0 };
            //Act
            for (var i = 0; i < numberToTest.Length; i++)
            {
                //Assert
                Assert.IsFalse(cs.isPrimeNumber(numberToTest[i]));
            }
        }

        [TestMethod]
        public void ShouldReturnTrueForThisLargePrimeNumber()
        {
            Assert.IsTrue(cs.isPrimeNumber(684473));
        }
    }
}
