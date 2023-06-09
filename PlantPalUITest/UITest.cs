using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.DevTools.V108.CSS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace PlantPalUITest
{
    [TestClass]
    public class UITest
    {
        private static readonly string url = "https://plantpalwebsite.azurewebsites.net/";
        private static readonly string driverDirectory = "C:/WebDriver/chromedriver.exe";
        private static readonly string driverDirectoryFF = "C:/WebDriver/geckodriver.exe";

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(driverDirectory);
            // _driver = new FirefoxDriver(driverDirectoryFF);
        }

        /*
        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }
        */

        [TestMethod]
        public void WebTitleTest()
        {
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("PlantPal", _driver.Title);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));



            IWebElement table = wait.Until(d => d.FindElement(By.Id("plantsTable")));


            string listText = table.Text;
            Assert.IsTrue(listText.Contains("tulip"));
        }
    }
}