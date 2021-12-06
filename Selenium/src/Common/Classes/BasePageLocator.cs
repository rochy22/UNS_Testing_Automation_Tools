using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Common.Classes
{
    public abstract class BasePageLocator
    {
        protected static IWebDriver Driver;
        protected static Actions Builder;

        public BasePageLocator()
        {
            Driver = Classes.Driver.Browser;
            Builder = new Actions(Driver);
        }

        public void AcceptAlert() => Driver.SwitchTo().Alert().Accept();

        public bool IsAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert();

                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public IWebElement AlertMsg => Driver.FindElement(By.CssSelector("div.alert_container > p"));

        public IWebElement CancelBtn => Driver.FindElement(By.XPath("//button[.='Cancel']"));

        public IWebElement CloseBtn => Driver.FindElement(By.XPath("//button[.='Close']"));

        public IWebElement Column(string name) => Driver.FindElement(By.CssSelector($"th[data-title='{name}']"));

        public IWebElement CompareSelectedOption(string dropDown, string optionSelected) => Driver.FindElement(By.XPath($"//li[@id='{dropDown}Id_option_selected'][contains(text(), '{optionSelected}')]"));

        public void CopyAndPaste(IWebElement from, IWebElement to)
        {
            Builder.KeyDown(Keys.Shift).SendKeys(from, Keys.Home).KeyUp(Keys.Shift).Perform();
            Builder.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();
            Builder.MoveToElement(to);
            Builder.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();
        }

        public IWebElement ConfirmBtn => Driver.FindElement(By.Id("btnConfirm"));

        public By ConfirmElement => By.XPath("//span[.='Confirm']");

        public IWebElement ConfirmFormBtn => Driver.FindElement(ConfirmElement);

        public IWebElement ConfirmFormDialog => Driver.FindElement(By.Id("dialog"));

        public string CurrentWindowHandle() => Driver.CurrentWindowHandle;

        public IWebElement CreationDateTxt => Driver.FindElement(By.CssSelector("tr:nth-child(1) > td.editor-field.bold"));

        public IWebElement ExportBtn => Driver.FindElement(By.Id("export"));

        public IWebElement ExportLimitLbl => Driver.FindElement(By.Id("popupExportErrorMessage"));

        public IWebElement FieldRequiredDlg(string field) => Driver.FindElement(By.CssSelector($"span[data-valmsg-for='{field}']"));

        public IList<IWebElement> FieldRequiredList(IWebElement field) => field.FindElements(By.XPath(".//*"));

        public IWebElement FieldRequiredValid(string field) => Driver.FindElement(By.CssSelector($"span.field-validation-valid[data-valmsg-for='{field}']"));

        public IWebElement FieldTxt(string field) => Driver.FindElement(By.Id($"{field}"));

        public IWebElement FilterBtn => Driver.FindElement(By.CssSelector("div.k-animation-container  button:nth-child(7)"));

        public IWebElement FilterBy(string filter) => Driver.FindElement(By.CssSelector($"th[data-title='{filter}'] span.k-icon.k-filter"));

        public IWebElement FilterLbl => Driver.FindElement(By.Id("gridFiltersAndSort"));

        public IWebElement FilterOptionDdl(int filter) => Driver.FindElement(By.XPath($"/html/body/div[5]/form/div[1]/span[{filter}]/span/span[2]/span[.='select']"));

        public IWebElement FilterSelectOption(int filter, string options) => Driver.FindElement(By.XPath($"//div[{filter}]/div/ul/li[.='{options}']"));

        public IWebElement FilterTwoTxt => Driver.FindElement(By.CssSelector(".k-animation-container input[data-bind='value: filters[1].value']"));

        public IWebElement FilterTxt => Driver.FindElement(By.CssSelector(".k-animation-container input[data-bind='value:filters[0].value']"));

        public IWebElement FooterTxt => Driver.FindElement(By.Id("footer"));

        public string GetTitle() => Driver.Title;

        public IWebElement InfoContainerMessageDlg => Driver.FindElement(By.CssSelector("#content div.ui-widget.alert_container > p"));

        public By ItemsPerPageElement => By.CssSelector("span.k-pager-sizes span.k-dropdown-wrap");

        public IWebElement ItemsPerPageDdl => Driver.FindElement(ItemsPerPageElement);

        public IWebElement ItemsPerPageSelect(int title) => Driver.FindElement(By.XPath($"//*[@role='listbox']/li[.='{title}']"));

        public IWebElement ItemsPerPageSelected(int items) => Driver.FindElement(By.XPath($"//div/ul/li[.='{items}']"));

        public IWebElement MainMenuLink(string options) => Driver.FindElement(By.XPath($"//a[.='{options}']"));

        public IWebElement MessageNoChangesDlg => Driver.FindElement(By.CssSelector("p.ui-state-highlight.ui-corner-all"));

        public By SaveElement => By.CssSelector("input.confirmForm");

        public IWebElement SaveBtn => Driver.FindElement(SaveElement);

        public void SwichToDefault() => Driver.SwitchTo().DefaultContent();

        public void SwitchToFrame(IWebElement Iframe) => Driver.SwitchTo().Frame(Iframe);

        public void SwitchToLast() => Driver.SwitchTo().Window(Driver.WindowHandles.Last());

        public void SwitchToNewWindowsTab() => Driver.SwitchTo().NewWindow(WindowType.Tab);

        public void SwitchToOriginalWindowsTab(string originalWindow) => Driver.SwitchTo().Window(originalWindow);

        public By TitleElement => By.ClassName("title");

        public IWebElement Title => Driver.FindElement(TitleElement);

        public IWebElement UsernameTxt => Driver.FindElement(By.CssSelector("#humanTabstrip-1 tr:nth-child(2) > td.editor-field.bold"));

        public void Wait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void Clickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void TextToBePresent(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public bool ExistElement(By element)
        {
            try
            {
                return Driver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string RunScript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            return (String)js.ExecuteScript(script);

        }
    }
}
