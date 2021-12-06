using Common.Classes;
using FMSWebPortal.Locators.Users.HumanUsers;
using FMSWebPortal.Shared.DataHelper;

namespace FMSWebPortal.PageObjects.Users.HumanUsers
{
    public class HumanUsersPage : BasePage
    {
        private readonly IndexLocators _indexLocator;
        private readonly DataHelper _data;

        public HumanUsersPage()
        {
            Url = "/HumanUser";
            _data = new DataHelper();
            _baseUrl = _data.GetBaseUrl();
            _indexLocator = new IndexLocators();
        }

        public void ClickNameColumnsButton() => _indexLocator.NameFormatBtn.Click();

    }
}
