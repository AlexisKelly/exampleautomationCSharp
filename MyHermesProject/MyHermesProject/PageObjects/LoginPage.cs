using MyHermesProject.UtilityHelper;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace MyHermesProject.PageObjects
{
    public class LoginPage : BasePage
    {
        public IWebElement PageHeader => DriverManager.driver.FindElement(By.CssSelector("[class='page-header']"));
        public IWebElement EmailTextField => DriverManager.driver.FindElement(By.Id("existingUser"));
        public IWebElement PasswordTextField => DriverManager.driver.FindElement(By.Id("existingPassword"));
        public IWebElement LoginBtn => DriverManager.driver.FindElement(By.Id("loginButton"));
        public IWebElement InvalidLogingMessage => DriverManager.driver.FindElement(By.CssSelector("[class='alert alert-danger ng-scope']"));

        public BasePage IChooseToLogin(string userEmail)
        {
            EmailTextField.SendKeys(userEmail);
            PasswordTextField.SendKeys(UserManager.GetUserPasswordBy(userEmail));
            LoginBtn.Click();
            CloseFeedBackPopupPromptIfDisplayed();
            if (DriverManager.driver.Url.Contains("login"))
            {
                return new LoginPage();
            }
            else
            {
                WaitUntilElementIsVisible(By.Id("logout-btn"));
                return new MyAccountPage();
            }
        }

        public LoginPage IChooseToLoginAsAnInvalidUser(string userEmail)
        {
            EmailTextField.SendKeys(userEmail);
            PasswordTextField.SendKeys(UserManager.GetUserPasswordBy(userEmail));
            LoginBtn.Click();
            CloseFeedBackPopupPromptIfDisplayed();
            return new LoginPage();
        }

    }
}
