using MyHermesProject.UtilityHelper;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace MyHermesProject.PageObjects
{
    public class BasePage
    {
        public const int TimeDuration = 60;

        public HomePage NavigateToSite()
        {
            DriverManager.driver.Navigate().GoToUrl(ConfigManager.UrlString);
            CloseFeedBackPopupPromptIfDisplayed();
            return new HomePage();
        }

        public bool PageTitleIs(string pageTitle)
        {
            string currentPageTitle = DriverManager.driver.Title;
            return currentPageTitle == pageTitle ? true : false;
        }

        //***********************************************WaitUntil*********************************************
        public void WaitUntilTitleIs(string pageTitle)
        {
            var wait = new WebDriverWait(DriverManager.driver, TimeSpan.FromSeconds(TimeDuration));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(pageTitle));
        }

        public void WaitUntilElementIsVisible(By locator, int waitDuration = TimeDuration)
        {
            var wait = new WebDriverWait(DriverManager.driver, TimeSpan.FromSeconds(waitDuration));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public bool WaitUntilElementIsNotVisible(By locator, int waitDuration = TimeDuration)
        {
            var wait = new WebDriverWait(DriverManager.driver, TimeSpan.FromSeconds(waitDuration));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        //***********************************************End of WaitUntil*********************************************

        public bool IsElementPresent(By locator)
        {
            try
            {
                DriverManager.driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void CloseFeedBackPopupPromptIfDisplayed()
        {
            if (IsElementPresent(By.CssSelector("[title=\"No, thanks\"]")))
            {
                DriverManager.driver.FindElement(By.CssSelector("[title=\"No, thanks\"]")).Click();
            }
        }


    }
}
