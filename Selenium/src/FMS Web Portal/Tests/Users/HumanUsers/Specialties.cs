using Common.Classes;
using FMSWebPortal.PageObjects;
using FMSWebPortal.PageObjects.Users.HumanUsers;
using Xunit;

namespace Users.HumanUsers
{
    [Collection("Collection #2")]
    public class Specialties : TestsBase
    {
        private readonly CreationEditonPage _createPage;
        private readonly LoginPage _loginPage;

        public Specialties()
        {
            _createPage = new CreationEditonPage();
            _loginPage = new LoginPage();
            _loginPage.Navigate();
            _loginPage.FillAndSubmit();
        }

        [Theory(DisplayName = "Relación entre Specialties y Robot PiP Enabled")]
        [InlineData(true)]
        [InlineData(false)]
        public void RF_05(bool specialtyEnabled)
        {
            _createPage.GoToCreationPage();
            _createPage.VerifySpecialty(specialtyEnabled);

        }
    }
}
