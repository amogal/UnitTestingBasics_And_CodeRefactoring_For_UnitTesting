using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoClassLibrary
{
    /// <summary>
    /// 1. Contains at least 8 or more charecters
    /// 2. Shouldn't match user's name, Dataset(amogal, nniverson)
    /// 3. Contains at least one Upper Case Letter and one Number
    /// 4. Can't be a recently used password
    /// 5. Contain at least one special charecter, Dataset : (@, !, $, ~, |)
    /// 6. Can't contain certain keywords, Dataset : (usa, 1234, crowe)
    /// </summary>
    public static class ValidatePassword
    {
        /// <summary>
        /// This is an example method with too much responsibility and its bad for unit testing  
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string PassWordValid(string password)
        {
            bool b = true;
            StringBuilder sb = new StringBuilder();

            //1.Contains at least 8 charecters
            b = (password.Length <= 8);
            if (!b)
            {
                sb.Append("Password must be at least 8 charecters long");
                sb.AppendLine();
            }

            //2.Shouldn't contain user's name           
            var username = new List<string>();
            //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; 
            username.Add("amogal");
            username.Add("nniverson");
            b = !username.Any(p => password.ToLower().Contains(p));
            if (!b)
            {
                sb.AppendLine();
                sb.Append("Password can't be same as username");
                sb.AppendLine();
            }


            //3.Contains One Upper Case Letter and 1 Number
            b = (!password.Any(char.IsUpper));
            if (!b)
            {
                sb.AppendLine();
                sb.Append("Password must contain at least one upper case letter");
                sb.AppendLine();
            }           

            b = (password.Any(char.IsDigit));
            if (!b)
            {
                sb.AppendLine();
                sb.Append("Password must contain at least one number");
                sb.AppendLine();
            }

            //4.Can't be a recently used password
            var recent = new List<string>();
            recent.Add("crowe123");
            recent.Add("sep2017");
            recent.Add("aug2017");
            b = !recent.Any(p => password.ToLower().Contains(p));

            if (!b)
            {
                sb.AppendLine();
                sb.Append("Password can't be same as a recent password");
                sb.AppendLine();
            }           
            
            //5.NOT contain special charecters  <, >, |
            b = password.ToLower().IndexOfAny(new char[] { '@', '!', '$', '|', '~'}) > 0;
            if (!b)
            {
                sb.AppendLine();
                sb.Append("Password must contain one special charecter");
                sb.AppendLine();
            }           

            //6.NOT contain certain keywords
            var keywords = new List<string>();
            keywords.Add("crowe");
            keywords.Add("usa");
            keywords.Add("1234");
            keywords.Add(DateTime.Now.Year.ToString());
            b = !keywords.Any(p => password.ToLower().Contains(p));
            if (!b)
            {
                sb.AppendLine();
                sb.Append("Password can't contain specific key words");
                sb.AppendLine();
            }            

            return sb.ToString();
        }
    }
}
