using Common.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FMSWebPortal.Locators.Users.HumanUsers
{
    public class CreationEditionLocators : BasePageLocator
    {
        public IWebElement ChallengeQuestionDdl(int field) => Driver.FindElement(By.CssSelector($"span[aria-owns='challengeQuestion{field}_listbox'] span.k-input"));

        public IWebElement ChallengeQuestionDdlSelect(string state, int field) => Driver.FindElement(By.XPath($"//*[@id='challengeQuestion{field}_listbox']/li[.='{state}']"));

        public IWebElement ChallengeQuestionLbl => Driver.FindElement(By.CssSelector($"label[for*='ChallengeQuestionId']"));

        public IWebElement ChallengeQuestionTwoLbl => Driver.FindElement(By.CssSelector($"label[for*='ChallengeQuestionTwoId']"));

        public IWebElement DefaultDdl(string field) => Driver.FindElement(By.Name($"{field}_input"));

        public IWebElement LocatorTxt(string field) => Driver.FindElement(By.Id($"{field}"));

        public IWebElement OrganizationLicenseDdl => Driver.FindElement(By.CssSelector("span[aria-owns='OrganizationLicenseDropdown_listbox'] span.k-input"));

        public IWebElement OrganizationLicenseDdlSelect(string state) => Driver.FindElement(By.XPath($"//*[@id='OrganizationLicenseDropdown_listbox']/li[.='{state}']"));

        public IWebElement OrganizationLicenseLbl => Driver.FindElement(By.CssSelector("label[for*= 'OrganizationLicenseId']"));

        public IWebElement OrganizationProviderDdl => Driver.FindElement(By.CssSelector("span[aria-owns='OrganizationDropdown_listbox'] span.k-input"));

        public IWebElement OrganizationProviderDdlSelect(string state) => Driver.FindElement(By.XPath($"//*[@id='OrganizationDropdown_listbox']/li[.='{state}']"));

        public IWebElement OrganizationProviderLbl => Driver.FindElement(By.CssSelector("label[for*= 'OrganizationProviderId']"));


        public IWebElement SectionBtn(string field) => Driver.FindElement(By.XPath($"//div/ul/li/a[.='{field}']"));

        public IWebElement StateDdl => Driver.FindElement(By.CssSelector("span[aria-owns='StateId_listbox'] span.k-input"));

        public IWebElement StateDdlSelect(string state) => Driver.FindElement(By.XPath($"//*[@id='StateId_listbox']/li[.='{state}']"));

        public IWebElement StateLbl => Driver.FindElement(By.CssSelector("label[for*= 'StateId']"));
  
        public void OrganizationInformationMouseover(IWebElement infoImg)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(infoImg);
            action.Perform();
        }
    }
}
