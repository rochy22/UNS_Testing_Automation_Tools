const defaultValues = require('../support/defaultValues');

class CreationPage{

    get inputUsername () { return $('#Username') }
    get inputFirstName () { return $('#FirstName') }
    get inputLastName () { return $('#LastName') }
    get EmailLocator () { return $('#Email') }
    get inputUsernameErrorMessage () { return $('[data-valmsg-for="Username"]') }
    get specialtyFieldLocator () { return $('#humanTabstrip-1 > table > tbody > tr:nth-child(7) > td:nth-child(5) > span.k-widget.k-combobox.k-header > span > input') }
    get specialtySelectedLocator () { return $('#SpecialtyId_option_selected') }
    get ProviderAccessLocator () { return $('#ProviderAccess') }
    get RobotPipEnabledLocator () { return $('#RobotPipEnabled') }
    get ApplicationsLocator () { return $('#humanTabstrip > ul > li.k-item.k-state-default.k-last > a') }
    get PersonalInformationLocator () { return $('#humanTabstrip > ul > li.k-item.k-state-default.k-first > a') }
    get SystemInformationLocator () { return $('#humanTabstrip > ul > li:nth-child(3) > a') }    
    get SecurityLocator () { return $('#humanTabstrip > ul > li:nth-child(2) > a') }
    get PasswordLocator () { return $('#Password') }
    get ConfirmPasswordLocator () { return $('#ConfirmPassword') }   
    get ConnectivityGroupLocator () { return $('#humanTabstrip-3 > table > tbody > tr:nth-child(1) > td:nth-child(2) > span.k-widget.k-combobox.k-header > span > input') }
    get ConnectivityGroupSelectedLocator () { return $('#ConnectivityGroupId_option_selected') }
    get SaveButtonLocator () {return $('#content > div > div:nth-child(2) > form > fieldset > p > input')}
    get ConfirmButtonLocator () {return $('body > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > button:nth-child(1) > span')}
    get Email2Locator () { return $('#Email2') }
    get MobileLocator () { return $('#Mobile') }
    get TitleLocator () { return $('#Title') }
    get ServiceLineLocator () { return $('#ServiceLine') }
    get CommentsLocator () { return $('#Comments') }
    get OfficePhoneLocator () { return $('#OfficePhone') }
    get CountryFieldLocator () { return $('#humanTabstrip-1 > table > tbody > tr:nth-child(5) > td:nth-child(5) > span.k-widget.k-combobox.k-header > span > input') }
    get CountrySelectedLocator () { return $('#CountryId_option_selected') }
    get ZipLocator () { return $('#Zip') } 
    get CityLocator () { return $('#City') } 
    get AddressLocator () { return $('#Address') } 
    get StateArrowLocator () { return $('#humanTabstrip-1 > table > tbody > tr:nth-child(3) > td:nth-child(5) > span.k-widget.k-dropdown.k-header > span > span.k-select > span') }
    get StateSelected () { return $('#StateId_listbox > li:nth-child(7)') }
    get EmployerLocator() { return $('#Employer') }
    get UsersGroupFieldLocator () { return $('#humanTabstrip-3 > table > tbody > tr:nth-child(2) > td:nth-child(2) > span.k-widget.k-combobox.k-header > span > input') }
    get UsersGroupSelectedLocator () { return $('#UsersGroupId_option_selected') }
    get EpicEmpIdLocator () { return $('#EpicEmpId') } 
    get IsEmployeeLocator () { return $('#IsEmployee') } 
    get PreferredTimezoneArrowLocator () { return $('#humanTabstrip-3 > table > tbody > tr:nth-child(7) > td.editor-field.required > span.k-widget.k-dropdown.k-header > span > span.k-select > span') } 
    get PreferredTimezoneSelectedLocator () { return $('#PreferredTimezone_listbox > li:nth-child(6)') }
    get NPILocator () { return $('#NationalProviderIdentifier') } 
    get OrganizationLicenseArrowLocator () { return $('#humanTabstrip-3 > table > tbody > tr:nth-child(4) > td:nth-child(2) > span.k-widget.k-dropdown.k-header > span > span.k-select > span') } 
    get OrganizationLicense() { return $('#OrganizationLicenseDropdown_listbox > li:nth-child(50)') } 
    get OrganizationProviderArrowLocator () { return $('#humanTabstrip-3 > table > tbody > tr:nth-child(5) > td:nth-child(2) > span.k-widget.k-dropdown.k-header > span > span.k-select > span') } 
    get OrganizationProvider() { return $('#OrganizationDropdown_listbox > li:nth-child(51)') } 
    get ChallengeQuestionArrowLocator () { return $('#humanTabstrip-2 > table > tbody > tr:nth-child(3) > td.editor-field.required > span.k-widget.k-dropdown.k-header > span > span.k-input') } 
    get ChallengeQuestion() { return $('#challengeQuestion1_listbox > li:nth-child(2)') } 
    get SecondChallengeQuestionArrowLocator () { return $('#humanTabstrip-2 > table > tbody > tr:nth-child(5) > td.editor-field.required > span.k-widget.k-dropdown.k-header > span > span.k-input') } 
    get SecondChallengeQuestion() { return $('#challengeQuestion2_listbox > li:nth-child(3)') }
    get SecondChallengeAnswerLocator() { return $('#challengeAnswer2') }
    get ChallengeAnswerLocator() { return $('#challengeAnswer1') }

    navigate () {
        return  browser.url('/HumanUser/Create');
    }

    async setUsername (username) {
        await this.inputUsername.setValue(username);
    }
    

    async getUsername () {
        return await this.inputUsername.getValue();
    }
    
    async setFirstName (name) {
        await this.inputFirstName.setValue(name);
    }

    async setLastName (name) {
        await this.inputLastName.setValue(name);
    }
    async setSpecialty (text) {
        await this.specialtyFieldLocator.setValue(text);
    }

    async setCountry (text) {
        await this.CountryFieldLocator.setValue(text);
    }

    async clickSpecialtySelected () {
        await this.specialtySelectedLocator.click();
    }

    async clickCountrySelected () {
        await this.CountrySelectedLocator.click();
    }

    async getRobotPipEnabled () {
        const elem = await this.RobotPipEnabledLocator.isSelected();
        return await elem
    }
    
     navigate () {
        return  browser.url('/HumanUser/Create');
    }

}

module.exports = new CreationPage();