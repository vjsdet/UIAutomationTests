using Newtonsoft.Json;
using UIAutomationTests.Models;
using UIAutomationTests.Utils;

namespace SpecFlow.Selenium.Models
{
    public class TestData
    {
        public SamplePageTest SamplePageTest { get; }

        const string DefaultEnvironment = "Dev";
        public TestData()
        {
            this.SamplePageTest = InitJson<SamplePageTest>("SamplePageTest.json");

        }

        public static string GetEnvironment()
        {

            string environment = EnvVar.ENV ?? DefaultEnvironment;
            return environment;
        }

        string GetJsonFolderPath()
        {
            string environment = GetEnvironment();
            string jsonFolderPath = Path.Combine(Environment.CurrentDirectory, "TestData", environment);
            return jsonFolderPath;
        }

        T InitJson<T>(string jsonFileName)
        {
            string jsonFolderPath = GetJsonFolderPath();
            string jsonFilePath = Path.Combine(jsonFolderPath, jsonFileName);
            if (!jsonFolderPath.EndsWith(DefaultEnvironment) && !File.Exists(jsonFilePath))
            {
                Util.Log.Info("Test data are using from master env");
                jsonFilePath = Path.Combine(Environment.CurrentDirectory, "TestData", DefaultEnvironment, jsonFileName);
            }
            string json = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
