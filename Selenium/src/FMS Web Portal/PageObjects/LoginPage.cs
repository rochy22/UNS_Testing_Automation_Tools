using Common.Classes;
using FMSWebPortal.Locators;
using FMSWebPortal.Shared.DataHelper;

namespace FMSWebPortal.PageObjects
{
    public class LoginPage : BasePage
    {
        private LoginPageLocators _locator;
        private DataHelper _data;

        public LoginPage()
        {
            Url = "/";
            _data = new DataHelper();
            _baseUrl = _data.GetBaseUrl();
            _locator = new LoginPageLocators();
        }

        public void ClickCreateAccountLink() => _locator.CreateAccount.Click();

        public void ClickForgotYourPasswordLink() => _locator.ForgotYourPassword.Click();

        public void ClickGoToEnterpriseLoginLink() => _locator.GoToEnterpriseLogin.Click();

        public void ClickLiveChatNowLink() => _locator.LiveChatNow.Click();

        public void SetEmailOrUsernameTextField(bool backendUser = true) => _locator.EmailOrUsername.SendKeys(backendUser ? _data.GetUsername() : _data.GetNoBackendUsername());

        public void SetPasswordPasswordField() => _locator.Password.SendKeys(_data.GetPassword());

        public void Submit() => _locator.SignIn.Click();

        public void FillAndSubmit(bool backendUser = true)
        {
            SetEmailOrUsernameTextField(backendUser);
            SetPasswordPasswordField();
            Submit();
        }
    }
}
