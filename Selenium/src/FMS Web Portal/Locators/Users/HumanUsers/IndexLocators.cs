using Common.Classes;
using OpenQA.Selenium;

namespace FMSWebPortal.Locators.Users.HumanUsers
{
    class IndexLocators : BasePageLocator
    {
        public IWebElement NameFormatBtn => Driver.FindElement(By.Id("toggle_ids"));

    }
}
