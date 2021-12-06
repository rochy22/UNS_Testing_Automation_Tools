using Common.Classes;
using FMSWebPortal.Helpers.Users;
using FMSWebPortal.PageObjects;
using FMSWebPortal.PageObjects.Users.HumanUsers;
using FMSWebPortal.Shared;
using FMSWebPortal.Shared.DataHelper;
using Xunit;

namespace Users.HumanUsers
{
    [Collection("Collection #3")]
    public class Username : TestsBase
    {
        private readonly CreationEditonPage _createPage;
        private readonly DataHelper _data;
        private readonly LoginPage _loginPage;

        public Username()
        {
            _createPage = new CreationEditonPage();
            _data = new DataHelper();
            _loginPage = new LoginPage();
            _loginPage.Navigate();
            _loginPage.FillAndSubmit();
        }


        [Fact(DisplayName = "Username - Caracteres permitidos")]
        public void RF_01()
        {
            _createPage.GoToCreationPage();
            _createPage.VerifyValidUsername();
            _createPage.VerifyInvalidUsername(RandomHelper.RandomString(invalidCharacters: true));
        }

        [Fact(DisplayName = "Username - Prefijos no permitidos")]
        public void RF_02()
        {
            _createPage.GoToCreationPage();
            _createPage.VerifyInvalidUsername("endpoint");
            _createPage.VerifyInvalidUsername("anyone");
        }

        [Fact(DisplayName = "Username - Unico")]
        public void RF_03()
        {
            _createPage.GoToCreationPage();
            _createPage.FillForm(UsersHelper.CreateBody());
            _createPage.VerifyFieldUnique(_data.GetUsername(), "Username");
            _createPage.VerifyFieldUnique(UsersHelper.GetRandomEnterpriseUser().Username, "Username");
        }

        [Fact(DisplayName = "Username - longitud permitida")]
        public void RF_04()
        {
            _createPage.GoToCreationPage();
            _createPage.VerifyValidUsername();
            _createPage.VerifyInvalidUsername(RandomHelper.RandomString(length: 65, username: true), invalid_length: true);
        }
    }
}
