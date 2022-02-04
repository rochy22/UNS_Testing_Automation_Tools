const { Given, When, Then, AfterAll } = require('@wdio/cucumber-framework');

const IdpPage = require('../pageobjects/idp.page');
const CreationPage = require('../pageobjects/creation.page');
const HomePage = require('../pageobjects/home.page');
const RandomHelper = require('../support/randomHelper');
const DefaultValues = require('../support/defaultValues');
const TokenSecret = require('../support/tokenSecret');
const  DatabaseConnection3 = require('../support/DatabaseConnection3');
const { expect } = require('chai');


Given("I am in the Creation section of the fms web portal", async () => {
    await IdpPage.open();
    await IdpPage.login(TokenSecret.username,TokenSecret.password);
    await browser.pause(2000);
    await CreationPage.navigate();
});

When("I input an invalid username with invalid characters", async () => {
    let invalidCharacters=DefaultValues.invalidCharacters;
    await CreationPage.setUsername(invalidCharacters);
    await CreationPage.setFirstName("test");
  });

When("I input an username of 65 characters", async () => {
    await CreationPage.setUsername(RandomHelper.getRandomUsername(true, 65))
    await CreationPage.setFirstName("test");
    await browser.pause(500);
  });

  When(/^I input an username with prefix (.*)$/, async (prefix) => {
    await CreationPage.setUsername(prefix);
    await CreationPage.setFirstName("test");
});

When(/^I input an (\w+) username$/, async (estado) => {
    let commonUser=true;
    let enabledUser=1;
    if(estado=='disable') enabledUser=0;
    if(estado=='enterprise') commonUser=false;
    let username= await DatabaseConnection3.getUser(commonUser,enabledUser);
    await CreationPage.setUsername(username);
    await CreationPage.setFirstName("test");
    await browser.pause(600);
  });


When(/^I input an Specialties whit default value=(\w+)$/, async (robotPipEnabled) => {
    let robotPipEnabledValue=1;
    if(robotPipEnabled=='false') robotPipEnabledValue=0
    let result=await DatabaseConnection3.getSpecialty(robotPipEnabledValue);
    await CreationPage.setSpecialty(result);
    await browser.pause(500);
    await CreationPage.clickSpecialtySelected();
});

When("I complete the required fields for a new user", async () => {
    let randomUsername='core_test_user_'+RandomHelper.getRandomNumber();
    await CreationPage.setUsername(randomUsername);
    await CreationPage.setFirstName(DefaultValues.defaultFirstName);
    await CreationPage.setLastName(DefaultValues.defaultLastName);
    await CreationPage.EmailLocator.setValue(randomUsername+DefaultValues.defaultDomain);
    
    await CreationPage.SystemInformationLocator.click();
    await browser.pause(500);
    await CreationPage.ConnectivityGroupLocator.setValue(DefaultValues.defaultConnectivityGroup);
    await browser.pause(500);
    await CreationPage.ConnectivityGroupSelectedLocator.click();
    
    await CreationPage.SecurityLocator.click();
    await browser.pause(500);
    CreationPage.PasswordLocator.setValue(DefaultValues.defaultPassword);
    await browser.pause(200);
    CreationPage.ConfirmPasswordLocator.setValue(DefaultValues.defaultPassword);
  });

  When("I complete all fields for a new user", async () => {
    let randomUsername='core_test_user_'+RandomHelper.getRandomNumber();
    await CreationPage.setUsername(randomUsername);
    await CreationPage.setFirstName(DefaultValues.defaultFirstName);
    await CreationPage.setLastName(DefaultValues.defaultLastName);
    await CreationPage.EmailLocator.setValue(randomUsername+DefaultValues.defaultDomain);
    await CreationPage.Email2Locator.setValue(DefaultValues.defaultEmail2);
    await CreationPage.MobileLocator.setValue(DefaultValues.defaultMobile);
    await CreationPage.TitleLocator.setValue(DefaultValues.defaultTitle);
    await CreationPage.ServiceLineLocator.setValue(DefaultValues.defaultServiceLine);
    await CreationPage.CommentsLocator.setValue(DefaultValues.defaultComments);
    await CreationPage.EmployerLocator.setValue(DefaultValues.defaultEmployer);
    await CreationPage.setSpecialty(DefaultValues.defaultSpecialty);
    await browser.pause(400);
    await CreationPage.clickSpecialtySelected();
    await CreationPage.OfficePhoneLocator.setValue(DefaultValues.defaultOfficePhone);
    await CreationPage.setCountry(DefaultValues.defaultCountryName);
    await browser.pause(400);
    await CreationPage.clickCountrySelected();    
    await CreationPage.ZipLocator.setValue(DefaultValues.defaultZip);
    await CreationPage.StateArrowLocator.click();
    await browser.pause(400)
    await CreationPage.StateSelected.click();
    await CreationPage.CityLocator.setValue(DefaultValues.defaultCity);
    await CreationPage.AddressLocator.setValue(DefaultValues.defaultAddress);

    await CreationPage.SystemInformationLocator.click();
    await browser.pause(500);
    await CreationPage.EpicEmpIdLocator.setValue(DefaultValues.defaultEpicEmpId);
    await CreationPage.IsEmployeeLocator.click();
    await CreationPage.PreferredTimezoneArrowLocator.click();
    await browser.pause(500);
    await CreationPage.PreferredTimezoneSelectedLocator.click();
    await CreationPage.NPILocator.setValue(DefaultValues.defaultNationalProviderIdentifier);
    await CreationPage.OrganizationProviderArrowLocator.click();
    await browser.pause(500);
    await CreationPage.OrganizationProvider.click();
    await CreationPage.OrganizationLicenseArrowLocator.click();
    await browser.pause(500);
    await CreationPage.OrganizationLicense.click();
    await CreationPage.UsersGroupFieldLocator.setValue(DefaultValues.defaultUsersGroup);
    await browser.pause(500);
    await CreationPage.UsersGroupSelectedLocator.click();
    await CreationPage.ConnectivityGroupLocator.setValue(DefaultValues.defaultConnectivityGroup);
    await browser.pause(500);
    await CreationPage.ConnectivityGroupSelectedLocator.click();
    
    await CreationPage.SecurityLocator.click();
    await browser.pause(500);
    await CreationPage.PasswordLocator.setValue(DefaultValues.defaultPassword);
    await browser.pause(200);
    await CreationPage.ConfirmPasswordLocator.setValue(DefaultValues.defaultPassword);
    await CreationPage.SecondChallengeQuestionArrowLocator.click();
    await browser.pause(200);
    await CreationPage.SecondChallengeQuestion.click();
    await CreationPage.ChallengeQuestionArrowLocator.click();
    await browser.pause(200);
    await CreationPage.ChallengeQuestion.click();
    await CreationPage.SecondChallengeAnswerLocator.setValue(DefaultValues.defaultChallengeAnswer);
    await CreationPage.ChallengeAnswerLocator.setValue(DefaultValues.defaultChallengeAnswer);
  });

Then("Required fields must have the expected value", async () => {
    await CreationPage.PersonalInformationLocator.click();
    let email=await CreationPage.EmailLocator.getValue()
    await CreationPage.SaveButtonLocator.click();
    await browser.pause(500); 
    await CreationPage.ConfirmButtonLocator.click();    
    await browser.pause(500); 
    let result=await DatabaseConnection3.verifyUser(email,true);
    expect(result).to.be.true;
  });  

  Then("All fields must have the expected value", async () => {
    await CreationPage.PersonalInformationLocator.click();
    let email=await CreationPage.EmailLocator.getValue();
    await CreationPage.SaveButtonLocator.click();
    await browser.pause(500);  
    await CreationPage.ConfirmButtonLocator.click(); 
    await browser.pause(500);    
    let result=await DatabaseConnection3.verifyUser(email,false);
    expect(result).to.be.true;
  }); 
 
Then("An error message should be displayed", async () => {
    let message= await CreationPage.inputUsernameErrorMessage.getText();
    await CreationPage.setFirstName(message);
    expect(DefaultValues.InvalidUsername).to.equal(message);
 });

 Then("An error message about the allowed length should be displayed", async () => {
    let message= await CreationPage.inputUsernameErrorMessage.getText();
    expect(DefaultValues.InvalidLengthUsername).to.equal(message);
});


Then("An error message that the user is already registered should be displayed", async () => {
    let message= await CreationPage.inputUsernameErrorMessage.getText();
    let username= await CreationPage.getUsername();
    let expectedMessage='The User with username "'+username+'" already exists. Please choose a different username.';
    expect(expectedMessage).to.equal(message);
});

Then("Log Out", async () => {
    await HomePage.LogOut();
});

Then(/^Robot PiP Enabled should be displayed as (\w+)$/, async (robotPipEnabled) => {
    await CreationPage.ApplicationsLocator.click();
    await browser.pause(500);
    await CreationPage.ProviderAccessLocator.click();
    let expectedRobotPipEnabled= await CreationPage.getRobotPipEnabled();
    if(robotPipEnabled=='true') expect(expectedRobotPipEnabled).to.be.true;
    else expect(expectedRobotPipEnabled).to.be.false;
    await browser.pause(500);

    await CreationPage.PersonalInformationLocator.click();
    await browser.pause(500);
    let inverseValue=0;
    if(robotPipEnabled=='false') inverseValue=1;
    let result=await DatabaseConnection3.getSpecialty(inverseValue);
    await CreationPage.setSpecialty(result);
    await browser.pause(500);
    await CreationPage.clickSpecialtySelected();
    await CreationPage.ApplicationsLocator.click();
    await browser.pause(500);
    let expectedNewRobotPipEnabled= await CreationPage.getRobotPipEnabled();
    if(inverseValue==1) expect(expectedNewRobotPipEnabled).to.be.true;
    else expect(expectedNewRobotPipEnabled).to.be.false;
 }); 