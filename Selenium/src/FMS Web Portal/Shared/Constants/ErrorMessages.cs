namespace FMSWebPortal.Shared.Constants.ErrorMessages
{
    public class ErrorMessages
    {
        public const string AllFiledsRequired = "All fields should be completed if staff member will be/is on PTO.";
        public const string ContainsName = "Password cannot contain the username, first name or last name.";
        public const string DisabledUser = "The entity is not enabled.";
        public const string ExportLimitExceeded = "The Export limit is 2000 rows. If you need further assistance please contact BusinessIntelligence@InTouchHealth.com";
        public const string InvalidCharacters = "Invalid characters. Multiple adjacent space characters are not allowed. Allowed characters are: a-z A-Z 0-9 _ - ( ) : . , + = @ * / \\ ;";
        public const string InvalidConfirmPassword = "Password and confirmation password do not match.";
        public const string InvalidEmail = "Invalid E-mail address.";
        public const string InvalidEmailConfirmation = "Email confirmation does not match the email.";
        public const string InvalidExternalProvider = "The External Provider value doesn't match with the existing Username prefix. Please keep the previous value or create a new user.";
        public const string InvalidFieldCharacters = "Invalid characters in field. Multiple adjacent space characters are not allowed. Allowed characters are: a-z A-Z 0-9 _ - ( ) : . , + = @ # * / \\ ;";
        public const string InvalidTextAreaCharacters = "Invalid characters in field. Multiple adjacent space characters are not allowed. Allowed characters are: a-z A-Z 0-9 _ - ( ) : . , + = @ # * / \\ and New Line character;";
        public const string InvalidLengthOrFormat = "Password must have a minimum of 8 characters and a maximum of 50. It must include at least: one uppercase letter, one lowercase letter, one numeric digit, and one punctuation symbol.";
        public const string InvalidLengthPhone = "The field Phone must be a number with a maximum of 50 digits.";
        public const string InvalidLocationCharacters = "Invalid characters in the Location Name. Multiple adjacent space characters, the character < or the character & followed by the character # are not allowed.";
        public const string InvalidPassword = "The current password is invalid.";
        public const string InvalidPhone = "Numbers, dashes, a leading plus-sign, parenthesis, and an extension are allowed. Example: +1 (877) 484-9119 ext 100";
        public const string InvalidRestriction = "Password cannot contain Username or FirstName or LastName.";
        public const string InvalidUsername = "Invalid Username: it must be lowercase, should not start with 'endpoint' or 'anyone'. Allowed characters: a-z, 0-9, '-', '_' and '.'";
        public const string RequiredRegionOnStaffMember = "The Staff Member should have at least 1 region associated.";
        public const string SamePassword = "The password cannot be the same as the current one.";
        public const string StartBeforeToEnd = "Start Date should be before to End Date for PTO.";
        public const string UnableToDisabled = "Unable to disable this care location as there is at least one active product associated to it.";
        public const string UniqueQuestions = "2nd Challenge Question cannot be the same as the first.";
        public const string InvalidLengthUsername = "The field Username must be a string with a maximum length of 64.";

        
        public static string AlreadyExists(string name, string nameField, string field) => $"The {name} with {nameField} \"{field}\" already exists. Please choose a different {nameField}.";

       }
}
