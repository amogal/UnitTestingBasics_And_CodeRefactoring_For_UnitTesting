using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using DemoClassLibrary;

namespace DemoUnitTest
{
 
    /// <summary>
    /// We usually organize test methods using AAA rule, A-Arrange, A-Act, A-Assert
    /// </summary>
    [TestClass]
     public class CalculatorFactoryTest
    {
        private decimal _DivideParam1;
        private decimal _DivideParam2;
        private decimal _DivideExpected;

        private decimal expected;
        private decimal a;
        private decimal b;
        CalculationFactory factory;
        public TestContext TestContext { get; set;}

        [TestInitialize]
        public void TestInitialize()
        {
            expected = 5;
            a = 20;
            b = 4;

            factory = new CalculationFactory();
        }

        #region Test Methods


        /// <summary>
        /// Simple Test method with hard-coded values
        /// </summary>
        //[ExpectedException(typeof(System.DivideByZeroException))]
        //[ExpectedException(typeof(System.FormatException))]
        [TestMethod]  
        [TestCategory("CalculationFactory")]              
        public void DivideTest()
        {
            //Arrange
            //Nothing to initialize here as we are utilizing The TestIntialize attribute

            //Act
            decimal actual=factory.Divide(a, b);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test method with the values coming from a config file, recommended for cleaner test mehtods
        /// </summary>        
        [TestMethod]
        [TestCategory("CalculationFactory")]
        public void DivideTest_UsingConfigFile()
        {
            //Arrange            
            SetDivideParams();
            
            //Act            
            decimal actual = factory.Divide(_DivideParam1, _DivideParam2);           

            //Assert            
            Assert.AreEqual(_DivideExpected, actual);
        }

        /// <summary>
        /// Test method demonstrating TestContext property which is automatically initiated and set by Unit Test framewrok
        /// Useful in debugging Unit Test methods, to see actual vs expected values etc...
        /// </summary>
        [TestMethod]
        [TestCategory("CalculationFactory")]
        public void DivideTest_UsingTestContextProperty()
        {
            //Arrange
            TestContext.WriteLine("Setting the method parameters....");
            SetDivideParams();
            TestContext.WriteLine("Values are Set. Param 1: " + _DivideParam1 + ", Param 2: " + _DivideParam1);

            //Act
            TestContext.WriteLine("Calling the CalculationFactory Divide funciton....");
            decimal actual = factory.Divide(_DivideParam1, _DivideParam2);
            TestContext.WriteLine("Actual calculated value is: " + actual);

            //Assert
            TestContext.WriteLine("Testing the Result");
            Assert.AreEqual(_DivideExpected, actual);
        }

        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod, TestCategory("CalculationFactory")]
        public void MultiplyTestNotImplemented()
        {
            //throw new NotImplementedException();
        }

        #endregion

        [TestCleanup]
       public void TestCleanup()
        {
            GC.Collect();
        }
       

        #region Supporting Methods

        /// <summary>
        /// This is a regualr method, YES test classes can have regular "supporting" methods, which are not executed directly
        /// </summary>
        private void SetDivideParams()
        {
            //Reading values from config file
            _DivideParam1 = decimal.Parse(ConfigurationManager.AppSettings["DivideParam1"].ToString());
            _DivideParam2 = decimal.Parse(ConfigurationManager.AppSettings["DivideParam2"].ToString());
            _DivideExpected = decimal.Parse(ConfigurationManager.AppSettings["DivideExpected"].ToString());
        }        

        #endregion
    }
}
