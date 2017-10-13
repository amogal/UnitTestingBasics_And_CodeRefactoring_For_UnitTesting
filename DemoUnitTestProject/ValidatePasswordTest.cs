using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoClassLibrary;

namespace DemoUnitTestProject
{
    [TestClass()]
    public class ValidatePasswordTest
    {


        //Invalid Password
        // private const string password = "amogal|2017";


        // Valid password    
        private const string password = "BlitzOct17";        

      

        /// <summary>
        ///Testing a method with too much responsiblity leads to uncertainity and sometimes non testable code
        /// </summary>
        [TestCategory("PasswordValidation"), TestMethod]
        public void PassWordValidTest()
        {
            Assert.IsTrue(string.IsNullOrEmpty(ValidatePassword.PassWordValid(password)));

            ////1.Contains at least 8 charecters
            //Assert.IsTrue(password.Length > 0);

            ////2. Shouldn't match user's name
            //Assert.IsTrue(password.Any(char.IsUpper) && password.Any(char.IsDigit));

            ////3.Contains One Upper Case Letter and one Number
            //var username = new List<string>();
            //username.Add("anwar");
            //username.Add("mogal");
            //Assert.IsTrue(!username.Any(p => password.ToLower().Contains(p)));

            ////4.NOT one of the 3 recently used passwords
            //var keywords = new List<string>();
            //keywords.Add("crowe");
            //keywords.Add("usa");
            //keywords.Add("horwath");
            //keywords.Add(DateTime.Now.Year.ToString());
            //Assert.IsTrue(!keywords.Any(p => password.ToLower().Contains(p)));

            ////5. NOT contain special charecters $, ~, %
            //var recent = new List<string>();
            //recent.Add("crowe123");
            //recent.Add("sep2017");
            //recent.Add("aug2017");
            //Assert.IsTrue(!recent.Any(p => password.ToLower().Contains(p)));

            ////6. NOT contain certain keywords
            //Assert.IsTrue(password.ToLower().IndexOfAny(new char[] { '$', '~', '%' }) == -1);

        }
    }
}
