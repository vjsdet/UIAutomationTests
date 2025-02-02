using System.Reflection;
using System.Text.RegularExpressions;

namespace UIAutomationTests.Utils
{
    public static class Util
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get { return log; } }

        public static string GetRootPath
        {
            get
            {
                string assemblyPath = Assembly.GetCallingAssembly().Location;
                string projectRootPath = assemblyPath.Substring(0, assemblyPath.LastIndexOf("bin"));
                return projectRootPath;
            }
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }
    }
}
