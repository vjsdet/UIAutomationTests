using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIAutomationTests.Models
{
    public static class EnvVar
    {
        public static string ENV { get; set; }
        public static string URL { get; set; }

        public static void GetEnvironmentVariables(TestContext testContext)
        {
            ENV = (string)testContext.Properties["ENV"];
            URL = (string)testContext.Properties["URL"];
        }
    }
}
