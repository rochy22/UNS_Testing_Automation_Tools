using System;
using OpenQA.Selenium;
using Xunit;

namespace Common.Classes
{
    public abstract class BasePage
    {
        protected readonly double Timeout = 15;
        protected string Url = "";
        protected string _baseUrl;

        public void Clear(IWebElement element)
        {
            element.SendKeys(Keys.Shift + Keys.Home);
            element.SendKeys(Keys.Delete);
        }

        public void FilterBy(BasePageLocator locator, string filter, string id = null)
        {
            locator.FilterBy(filter).Click();
            Clear(locator.FilterTxt);
            locator.FilterTxt.SendKeys(id);
            locator.FilterBtn.Click();
        }

        public string GetPage(string page, string id) => _baseUrl + Url + $"/{page}/{id}";

        public void GoTo(string url) => Driver.Browser.Navigate().GoToUrl(url);

        public void GoToCreationPage(string rute = "Create") => Driver.Browser.Navigate().GoToUrl(_baseUrl + Url + $"/{rute}");

        public void GoToEditionPage(long id) => Driver.Browser.Navigate().GoToUrl(_baseUrl + Url + $"/Edit/{id}");

        public void GoToEditionPage(Guid id) => Driver.Browser.Navigate().GoToUrl(_baseUrl + Url + $"/Edit/{id}");

        public void GoToLogsPage(long id) => Driver.Browser.Navigate().GoToUrl(_baseUrl + Url + $"/History/{id}");

        public void Navigate() => Driver.Browser.Navigate().GoToUrl(_baseUrl + Url);

        public void VerifyIndexPage(BasePageLocator locator, string name)
        {
            Assert.True(locator.Title.Displayed);
            Assert.Equal(name, locator.Title.Text);
            Assert.True(locator.MainMenuLink(name).Enabled);
            Assert.Equal(_baseUrl + Url, locator.MainMenuLink(name).GetAttribute("href"));
        }

        public void VerifyPageUrl() => Assert.Contains(Url, Driver.Browser.Url);

        public void VerifyPageUrl(string url) => Assert.Contains(url, Driver.Browser.Url);

        public void VerifyNotErrorOnField(IWebElement element)
        {
            Assert.False(element.Displayed);
            Assert.Empty(element.Text);
            Assert.Equal("field-validation-valid", element.GetAttribute("class"));
        }
    }
}
