using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyHermesProject.Basic
{
    [TestClass]
    public class UnitTest1
    {

        public IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.myhermes.co.uk/");
        }
    }
}
