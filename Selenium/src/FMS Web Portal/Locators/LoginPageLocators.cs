using Common.Classes;
using OpenQA.Selenium;

namespace FMSWebPortal.Locators
{
    public class LoginPageLocators : BasePageLocator
    {
        public IWebElement CreateAccount => Driver.FindElement(By.CssSelector("a.btn-new-account.btn.btn-block"));

        public IWebElement EmailOrUsername => Driver.FindElement(By.Id("UsernameOrEmail"));

        public IWebElement ForgotYourPassword => Driver.FindElement(By.CssSelector("a.forgot-hyperlink"));

        public IWebElement GoToEnterpriseLogin => Driver.FindElement(By.CssSelector("a.btn.btn-primary.btn-block"));

        public IWebElement LiveChatNow => Driver.FindElement(By.CssSelector("a.livechat-hyperlink"));

        public IWebElement Password => Driver.FindElement(By.Id("password"));

        public IWebElement SignIn => Driver.FindElement(By.CssSelector("button[value='login']"));
    }
}
