using System.Threading;
using Common.Classes;
using FMSWebPortal.Helpers.Users;
using FMSWebPortal.Locators.Users.HumanUsers;
using FMSWebPortal.Models;
using FMSWebPortal.Shared;
using FMSWebPortal.Shared.Constants.ErrorMessages;
using FMSWebPortal.Shared.DataHelper;
using OpenQA.Selenium;
using Xunit;

namespace FMSWebPortal.PageObjects.Users.HumanUsers
{
    class CreationEditonPage : BasePage
    {
        private readonly CreationEditionLocators _formLocator;
        private readonly DataHelper _data;

        public CreationEditonPage()
        {
            Url = "/HumanUser";
            _data = new DataHelper();
            _baseUrl = _data.GetBaseUrl();
            _formLocator = new CreationEditionLocators();
        }

        public void ClickConfirmBtn()
        {
            _formLocator.Wait(_formLocator.ConfirmElement);
            _formLocator.ConfirmFormBtn.Click();
        }

        public void ClickSaveBtn()
        {
            _formLocator.Clickable(_formLocator.SaveElement);
            _formLocator.SaveBtn.Click();
        }

        public void FillForm(HumanUser hu, bool fillOptionals = false)
        {
            _formLocator.LocatorTxt("Username").SendKeys(hu.Username);
            _formLocator.LocatorTxt("FirstName").SendKeys(hu.FirstName);
            _formLocator.LocatorTxt("LastName").SendKeys(hu.LastName);
            _formLocator.LocatorTxt("Email").SendKeys(hu.Email);

            if (fillOptionals)
            {
                _formLocator.LocatorTxt("Address").SendKeys(hu.Address);
                _formLocator.LocatorTxt("City").SendKeys(hu.City);
                _formLocator.LocatorTxt("Comments").SendKeys(hu.Comments);
                _formLocator.DefaultDdl("CountryId").SendKeys(hu.Country + Keys.Tab);
                _formLocator.LocatorTxt("Email2").SendKeys(hu.AlternativeEmail);
                _formLocator.LocatorTxt("Employer").SendKeys(hu.Employer);
                _formLocator.LocatorTxt("Mobile").SendKeys(hu.Mobile);
                _formLocator.LocatorTxt("OfficePhone").SendKeys(hu.OfficePhone);
                _formLocator.LocatorTxt("ServiceLine").SendKeys(hu.ServiceLine);
                _formLocator.DefaultDdl("SpecialtyId").SendKeys(hu.Specialty + Keys.Tab);
                _formLocator.StateDdl.Click();
                Thread.Sleep(400);
                _formLocator.StateDdlSelect(hu.State).Click();
                _formLocator.StateLbl.Click();
                _formLocator.LocatorTxt("Title").SendKeys(hu.Title);
                _formLocator.LocatorTxt("Zip").SendKeys(hu.Zip);
            }

            _formLocator.SectionBtn("Security").Click();
            Thread.Sleep(300);
            _formLocator.LocatorTxt("Password").SendKeys(_data.GetPasswordDisable());
            _formLocator.LocatorTxt("ConfirmPassword").SendKeys(_data.GetPasswordDisable());

            if (fillOptionals)
            {
                _formLocator.ChallengeQuestionDdl(1).Click();
                Thread.Sleep(400);
                _formLocator.ChallengeQuestionDdlSelect(hu.ChallengeQuestion, 1).Click();
                _formLocator.ChallengeQuestionLbl.Click();

                _formLocator.ChallengeQuestionDdl(2).Click();
                Thread.Sleep(400);
                _formLocator.ChallengeQuestionDdlSelect(hu.ChallengeQuestionTwo, 2).Click();
                _formLocator.ChallengeQuestionTwoLbl.Click();

                _formLocator.LocatorTxt("challengeAnswer1").SendKeys(hu.ChallengeAnswer);
                _formLocator.LocatorTxt("challengeAnswer2").SendKeys(hu.ChallengeAnswerTwo);
            }

            _formLocator.SectionBtn("System Information").Click();
            Thread.Sleep(200);
            _formLocator.SectionBtn("System Information").Click();

            _formLocator.DefaultDdl("ConnectivityGroupId").SendKeys(hu.ConnectivityGroup + Keys.Tab);

            if (fillOptionals)
            {
                _formLocator.DefaultDdl("UsersGroupId").SendKeys(hu.UserGroup + Keys.Tab);

                _formLocator.OrganizationLicenseDdl.Click();
                Thread.Sleep(400);
                _formLocator.OrganizationLicenseDdlSelect(hu.OrganizationLicense).Click();
                _formLocator.OrganizationLicenseLbl.Click();

                _formLocator.OrganizationProviderDdl.Click();
                Thread.Sleep(400);
                _formLocator.OrganizationProviderDdlSelect(hu.OrganizationProvider).Click();
                _formLocator.OrganizationProviderLbl.Click();

                _formLocator.LocatorTxt("NationalProviderIdentifier").SendKeys(hu.Npi.ToString());
                _formLocator.LocatorTxt("EpicEmpId").SendKeys(hu.EpicEmpId);
            }

            _formLocator.SectionBtn("Personal Information").Click();
            Thread.Sleep(200);
            _formLocator.SectionBtn("Personal Information").Click();
        }


        public void SetDdlField(string field, string data)
        {
            Clear(_formLocator.DefaultDdl(field));
            _formLocator.DefaultDdl(field).SendKeys(data + Keys.Tab);
        }

        public void SetField(string field, string data)
        {

            Clear(_formLocator.LocatorTxt(field));
            _formLocator.LocatorTxt(field).SendKeys(data + Keys.Tab);
        }



        public void VerifyData(HumanUser hu, FmsDbContext.Users humanUserSaved, bool withOptionals = false)
        {
            FmsDbContext.ConnectivityGroups expectedConnectivityGroupId = UsersHelper.ConnectivityGroupByName(hu.ConnectivityGroup);

            Assert.Equal(hu.Username, humanUserSaved.Username);
            Assert.Equal(hu.FirstName, humanUserSaved.HumanUsers.FirstName);
            Assert.Equal(hu.LastName, humanUserSaved.HumanUsers.LastName);
            Assert.Equal(hu.Email, humanUserSaved.HumanUsers.Email);

            if (withOptionals)
            {

                var expectedCountryId = UsersHelper.ContryByName(hu.Country);
                var expectedSpecialtyId = UsersHelper.SpecialtyByName(hu.Specialty);

                Assert.Equal(hu.Address, humanUserSaved.HumanUsers.Address);
                Assert.Equal(hu.City, humanUserSaved.HumanUsers.City);
                Assert.Equal(hu.Comments, humanUserSaved.HumanUsers.Comments);
                Assert.Equal(expectedCountryId.CountryId, humanUserSaved.HumanUsers.CountryId);
                Assert.Equal(hu.AlternativeEmail, humanUserSaved.HumanUsers.Email2);
                Assert.Equal(hu.Employer, humanUserSaved.HumanUsers.Employer);
                Assert.Equal(hu.Mobile, humanUserSaved.HumanUsers.Mobile);
                Assert.Equal(hu.OfficePhone, humanUserSaved.HumanUsers.OfficePhone);
                Assert.Equal(hu.ServiceLine, humanUserSaved.HumanUsers.ServiceLine);
                Assert.Equal(expectedSpecialtyId.SpecialtyId, humanUserSaved.HumanUsers.SpecialtyId);
                Assert.Equal(hu.Title, humanUserSaved.HumanUsers.Title);
                Assert.Equal(hu.Zip, humanUserSaved.HumanUsers.Zip);
            }
            else
            {
                Assert.Null(humanUserSaved.HumanUsers.Address);
                Assert.Null(humanUserSaved.HumanUsers.City);
                Assert.Null(humanUserSaved.HumanUsers.Comments);
                Assert.Null(humanUserSaved.HumanUsers.CountryId);
                Assert.Null(humanUserSaved.HumanUsers.Email2);
                Assert.Null(humanUserSaved.HumanUsers.Employer);
                Assert.Null(humanUserSaved.HumanUsers.Mobile);
                Assert.Null(humanUserSaved.HumanUsers.OfficePhone);
                Assert.Null(humanUserSaved.HumanUsers.ServiceLine);

                Assert.Null(humanUserSaved.HumanUsers.SpecialtyId);
                Assert.Null(humanUserSaved.HumanUsers.Title);
                Assert.Null(humanUserSaved.HumanUsers.StateId);
                Assert.Null(humanUserSaved.HumanUsers.Zip);

                Assert.Null(humanUserSaved.HumanUsers.ChallengeQuestion);
                Assert.Null(humanUserSaved.HumanUsers.ChallengeQuestionTwo);
                Assert.Null(humanUserSaved.HumanUsers.AnswerOne);
                Assert.Null(humanUserSaved.HumanUsers.AnswerTwo);

            }

            Assert.Equal(expectedConnectivityGroupId.ConnectivityGroupId, humanUserSaved.HumanUsers.ConnectivityGroupId);
        }


        public void VerifyFieldUnique(string field, string nameField)
        {
            Thread.Sleep(600);
            SetField(nameField, field);
            Thread.Sleep(600);
            _formLocator.LocatorTxt(nameField).SendKeys(Keys.Tab);
            Thread.Sleep(800);

            Assert.True(_formLocator.FieldRequiredDlg(nameField).Displayed);
            Assert.Equal(ErrorMessages.AlreadyExists("User", nameField.ToLower(), field), _formLocator.FieldRequiredDlg(nameField).Text);
        }


        public void VerifySpecialty(bool robotPipEnabled)
        {
            var specialtyName = UsersHelper.SpecialtyName(robotPipEnabled);
            SetDdlField("SpecialtyId", specialtyName);
            _formLocator.SectionBtn("Applications").Click();
            _formLocator.LocatorTxt("ProviderAccess").Click();
            Thread.Sleep(600);

            Assert.Equal(_formLocator.LocatorTxt("RobotPipEnabled").Selected, robotPipEnabled);

            specialtyName = UsersHelper.SpecialtyName(!robotPipEnabled);

            _formLocator.SectionBtn("Personal Information").Click();
            Thread.Sleep(600);
            Clear(_formLocator.DefaultDdl("SpecialtyId"));
            _formLocator.DefaultDdl("SpecialtyId").SendKeys(specialtyName);
            Thread.Sleep(300);
            _formLocator.LocatorTxt("SpecialtyId_option_selected").Click();
            _formLocator.SectionBtn("Applications").Click();
            Thread.Sleep(600);


            Assert.Equal(_formLocator.LocatorTxt("RobotPipEnabled").Selected, !robotPipEnabled);
        }

        public void VerifyInvalidUsername(string username, bool invalid_length = false)
        {
            var errormessage = invalid_length ? ErrorMessages.InvalidLengthUsername : ErrorMessages.InvalidUsername;
            SetField("Username", username);
            Thread.Sleep(900);
            _formLocator.LocatorTxt("Username").SendKeys(Keys.Tab + Keys.Tab);
            Thread.Sleep(600);

            Assert.Equal(errormessage, _formLocator.FieldRequiredDlg("Username").Text);

            _formLocator.LocatorTxt("Username").Clear();
        }

        public void VerifyValidUsername()
        {
            SetField("Username", RandomHelper.RandomString(10, username: true));

            VerifyNotErrorOnField(_formLocator.FieldRequiredDlg("Username"));
        }
    }
}
