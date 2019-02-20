using MyHermesProject.UtilityHelper;
using OpenQA.Selenium;
using System;


namespace MyHermesProject.PageObjects
{
    public class HomePage : BasePage
    {
        public IWebElement HideCookieMsg => DriverManager.driver.FindElement(By.Id("hide-cookie-message"));
        public IWebElement LoginBtn => DriverManager.driver.FindElement(By.Id("login-btn"));

        public LoginPage ChooseToNavigateToLoginPage()
        {
            AcceptCookiesIfDisplayed();
            LoginBtn.Click();
            CloseFeedBackPopupPromptIfDisplayed();
            WaitUntilElementIsVisible(By.Id("existingUser"));
            return new LoginPage();
        }

        public void AcceptCookiesIfDisplayed()
        {
            if (IsElementPresent(By.Id("hide-cookie-message")))
            {
                ((IJavaScriptExecutor)DriverManager.driver).ExecuteScript("arguments[0].click();",
                    HideCookieMsg);
            }
        }

    }
}
