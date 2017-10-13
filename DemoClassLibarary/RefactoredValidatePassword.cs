using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoClassLibrary
{
    public static class RefactoredValidatePassword
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        private static Dictionary<int, string> alerts = new Dictionary<int, string>();
        private static StringBuilder sb = new StringBuilder();

        public static string PassWordValid(string password)
        {
            bool b = true;
            PopulateAlerts();

            //1.Contains at least 8 charecters
            b = (CheckPasswordLength(password));
            if(!b) AddAlert(1);

            //2.Shouldn't contain user's name
            b = CheckForUserNameMatch(password);
            if (!b) AddAlert(2);

            //3.Contains One Upper Case Letter and 1 Number
            b = (CheckUpperCaseAndNumeric(password));
            if (!b) AddAlert(3);
            b = (password.Any(char.IsDigit));
            if (!b) AddAlert(4);

            //4.NOT one of the 3 recently used passwords
            b = CheckForRecentPasswords(password);
            if (!b) AddAlert(5);

            //5.NOT contain certain special charecters <, >, |         
            b = CheckForSpecialCharecters(password);
            if (!b) AddAlert(6);

            //6.NOT contain certain keywords
            b = CheckForKeywords(password);
            if (!b) AddAlert(7);

            return sb.ToString();
        }

        public static bool CheckUpperCaseAndNumeric(string password)
        {
            return (!password.Any(char.IsUpper) && password.Any(char.IsDigit));            
            
        }
        public static bool CheckPasswordLength(string password)
        {
            return (password.Length <= 8);
        }

        public static bool CheckForSpecialCharecters(string password)
        {
            return password.ToLower().IndexOfAny(new char[] { '<', '>', '|' }) > 0;            
        }

        public static bool CheckForKeywords(string password)
        {
            var keywords = new List<string>();
            keywords.Add("crowe");
            keywords.Add("usa");
            keywords.Add("horwath");
            keywords.Add(DateTime.Now.Year.ToString());
            return (!keywords.Any(p => password.ToLower().Contains(p)));
            
        }

        public static bool CheckForRecentPasswords(string password)
        {
            var recent = new List<string>();
            recent.Add("crowe123");
            recent.Add("sep2017");
            recent.Add("aug2017");
            return (!recent.Any(p => password.ToLower().Contains(p)));
            
        }

        public static bool CheckForUserNameMatch(string password)
        {
            var username = new List<string>();
            //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; 
            username.Add("amogal");
            username.Add("nniverson");
            return(!username.Any(p => password.ToLower().Contains(p)));            
        }


        private static void PopulateAlerts()
        {
            alerts.Add(1, "Password must be at least 8 charecters long");
            alerts.Add(2, "Password can't be same as username");
            alerts.Add(3, "Password must contain at least one upper case letter and one number");
            //alerts.Add(4, "Password must contain at least one number");
            alerts.Add(5, "Password can't be same as a recent password");
            alerts.Add(6, "Password must contain at least one special charecter");
            alerts.Add(7, "Password can't contain specific key words");
        }
        public static void AddAlert(int index)
        {
            if (sb.Length > 0) sb.AppendLine();
            sb.Append(alerts[index]);
            sb.AppendLine();
        }        
    }
}