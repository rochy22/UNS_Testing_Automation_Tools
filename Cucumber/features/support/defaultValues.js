class defaultValues{
  
    InvalidUsername = "Invalid Username: it must be lowercase, should not start with 'endpoint' or 'anyone'. Allowed characters: a-z, 0-9, '-', '_' and '.'";
    InvalidLengthUsername= "The field Username must be a string with a maximum length of 64.";

    lowercaseAccentedCharacters = "äëïöüâêîôûáéíóúàèìùò";
    uppercaseAccentedCharacters = "ÄËÏÖÜÂÊÎÔÛÁÉÍÓÚÀÈÌÒÙ";
    uppercase = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
    lowercase = "abcdefghijkmnopqrstuvwxyz";
    numbers="1234567890";
    punctuationSymbol=".:;_-";
    validCharacters=this.uppercase+this.lowercase+this.numbers+"_-():.,+=@*/\;."
    username="abcdefghijklmnopqrstuvwxyz0123456789-_.";
    invalidCharacters="!@#$%^&*("
    name=this.uppercase+this.lowercase+this.lowercaseAccentedCharacters+this.uppercaseAccentedCharacters+"+.-"
    local=this.uppercase+this.lowercase+this.numbers+"!#$%&*+-/=?^_{|}~";
    domain=this.uppercase+this.lowercase+this.numbers+"-";

    defaultFirstName='test';
    defaultLastName='test';
    defaultDomain='@mailinator.com';
    defaultPassword='Password-1234';
    defaultConnectivityGroup='core_qa_conngroup_01';
    defaultEmail2='test_user_1234@mailinator.com';
    defaultAddress='test Address';
    defaultMobile='1234';
    defaultOfficePhone='4321';
    defaultTitle='test Title';
    defaultSpecialty='Anesthesiology';
    defaultComments='test comments';
    defaultChallengeQuestionId=13;
    defaultChallengeQuestionTwoId=6;
    defaultServiceLine='test ServiceLine';
    defaultEmployer='test Employer';
    defaultCity='test City';
    defaultState ='Colorado';
    defaultZip='1111';
    defaultCountryId=236;
    defaultCountryName='United States';
    defaultUsersGroup='core_qa_user_group_01';
    defaultOrganizationLicense ='core_qa_organization_01';
    defaultOrganizationProviderId='core_qa_organization_02';
    defaultPreferredTimezone='Alaskan Standard Time';
    defaultIsEmployee=1;
    defaultIsEnabled=1;
    defaultNationalProviderIdentifier=4279303323;
    defaultEpicEmpId='12345';
    defaultChallengeAnswer='test Challenge Answers';
    }

module.exports = new defaultValues();