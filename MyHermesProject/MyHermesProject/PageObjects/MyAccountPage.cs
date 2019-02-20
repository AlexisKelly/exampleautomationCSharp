using MyHermesProject.UtilityHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;


namespace MyHermesProject.PageObjects
{
    class MyAccountPage : BasePage
    {
        public IWebElement MyAccountIconBtn => DriverManager.driver.FindElement(By.Id("logout-btn"));
        public IWebElement MyAccountIconDropdown => DriverManager.driver.FindElement(By.CssSelector("[class='btn btn-inverse-primary btn-md dropdown-toggle']"));

        //how to implement drown down elements
        public SelectElement MyAccountIconDropdownBtn => new SelectElement(MyAccountIconDropdown);

        public string getMessageDisplayed(string messageText) => DriverManager.driver.FindElements(By.CssSelector("[class='strapline strapline-light']"))
                .First(x => x.Text.Equals(messageText)).Text;

    }
}
