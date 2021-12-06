using Common.Classes;
using FMSWebPortal.Helpers.Users;
using FMSWebPortal.PageObjects;
using FMSWebPortal.PageObjects.Users.HumanUsers;
using Xunit;

namespace Users.HumanUsers
{
    [Collection("Collection #1")]
    public class Database : TestsBase
    {
        private readonly CreationEditonPage _createPage;
        private readonly LoginPage _loginPage;

        public Database()
        {
            _createPage = new CreationEditonPage();
            _loginPage = new LoginPage();
            _loginPage.Navigate();
            _loginPage.FillAndSubmit();
        }

        [Fact(DisplayName = "Almacenamiento de elementos requeridos")]
        public void RF_06()
        {
            var humanUser = UsersHelper.CreateBody();

            _createPage.GoToCreationPage();
            _createPage.FillForm(humanUser);
            _createPage.ClickSaveBtn();
            _createPage.ClickConfirmBtn();

            var humanUserSaved = UsersHelper.GetByUsername(humanUser.Username);

            _createPage.VerifyData(humanUser, humanUserSaved);
        }

        [Fact(DisplayName = "Almacenamiento del usuario")]
        public void RF_07()
        {
            var humanUser = UsersHelper.CreateBody(true);

            _createPage.GoToCreationPage();
            _createPage.FillForm(humanUser, true);
            _createPage.ClickSaveBtn();
            _createPage.ClickConfirmBtn();

            var humanUserSaved = UsersHelper.GetByUsername(humanUser.Username);

            _createPage.VerifyData(humanUser, humanUserSaved, true);
        }
    }
}
