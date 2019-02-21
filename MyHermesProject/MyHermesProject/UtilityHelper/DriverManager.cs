using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.IO;
using TechTalk.SpecFlow;


namespace MyHermesProject.UtilityHelper
{
    [Binding]
    public class DriverManager
    {
        public static IWebDriver driver;
        private static string screenShotSavePath = AppDomain.CurrentDomain.BaseDirectory + @"\..|..|ScreenShots\";

        [BeforeScenario]
        public static void BeforeScenario()
        {
            InitializeBrowser();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            ClearUpTest();
        }

        public static void InitializeBrowser()
        {
            var test = ConfigManager.UrlString;
            switch (ConfigManager.BrowsersType)
            {
                case "chrome":
                    Console.WriteLine("Opening Chrome Browser");
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    Console.WriteLine("Opening Firefox Browser");
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    Console.WriteLine("Opening Edge Browser");
                    driver = new EdgeDriver();
                    break;

                default:
                    Assert.Fail("Wrong browser specified");
                    break;
            }
            driver.Manage().Window.Maximize();
        }

        public static void CloseBrowser()
        {
            if(driver != null)
            {
                Console.WriteLine("\r\n" + "Close Browser" + "\r\n");
                driver.Quit();
            }
        }

        public static void ClearUpTest()
        {
            bool scenarioPassed = ScenarioContext.Current.TestError == null;
            string scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            string todayDate = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss tt");
            string pageTitle = driver.Title;

            string screenShotName = scenarioName + "-" + pageTitle + "-" + todayDate;

            try
            {
                if (!scenarioPassed)
                {
                    Console.WriteLine($"\r\nTest scenario: {0} [Failed] \r\nSee screenshot with following name: {scenarioName} {pageTitle}-{todayDate}");

                    CreateFolderInPathIfOneDoesntExistAlready(screenShotSavePath);

                    Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenShot.SaveAsFile(screenShotSavePath + screenShotName + ".png", ScreenshotImageFormat.Png);
                } else
                {
                    Console.WriteLine("\r\nTest scenario: {0} [Passed]", scenarioName);
                }
            }
            catch (Exception e)
            {
                CloseBrowser();
                Console.WriteLine(e);
            }
            CloseBrowser();
        }

        public static void CreateFolderInPathIfOneDoesntExistAlready(string locationAndName)
        {
            try
            {
                if (!Directory.Exists(locationAndName))
                {
                    Directory.CreateDirectory(locationAndName);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
