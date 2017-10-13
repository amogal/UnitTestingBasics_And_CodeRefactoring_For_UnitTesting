using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blitz2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoClassLibrary;

namespace Blitz2017.Tests
{
    [TestClass()]
    public class RefactoredValidatePasswordTest
    {
        string password = "";

        [TestInitialize]
        public void TestInitialize()
        {
            //Invalid password
             //password = "amogal2017|";


            //Valid password
             password = "Blitz@Oct17";

            /*This is a simple example, this method will be helpful when dealing with 
            Object instainiation etc, so that they will be available in all the test mehtods */
        }


        #region Test methods for refactored validation

        /* In below methods the responsibilities are nicely broken down so its easier to write unit tests */

        [TestCategory("RefactoredPasswordValidation"), TestMethod]
        public void CheckUpperCaseAndNumericTest()
        {
            Assert.IsTrue(RefactoredValidatePassword.CheckUpperCaseAndNumeric(password));
        }

        [TestCategory("RefactoredPasswordValidation"), TestMethod]
        public void CheckPasswordLengthTest()
        {
            Assert.IsTrue(RefactoredValidatePassword.CheckPasswordLength(password));
        }

        [TestCategory("RefactoredPasswordValidation"), TestMethod]
        public void CheckForUserNameMatchTest()
        {                  
            Assert.IsTrue(RefactoredValidatePassword.CheckForUserNameMatch(password));
        }

        [TestCategory("RefactoredPasswordValidation"), TestMethod]
        public void CheckForKeywordsTest()
        {
            Assert.IsTrue(RefactoredValidatePassword.CheckForKeywords(password));
        }

        [TestCategory("RefactoredPasswordValidation"), TestMethod]
        public void CheckForRecentPasswordsTest()
        {
            Assert.IsTrue(RefactoredValidatePassword.CheckForRecentPasswords(password));
        }

        [TestCategory("RefactoredPasswordValidation"), TestMethod]
        public void CheckForSpecialCharectersTest()
        {
            Assert.IsTrue(RefactoredValidatePassword.CheckForSpecialCharecters(password));
        }

        #endregion 

        [TestCleanup]
        public void TestCelanup()
        {

        }
                
    }
}