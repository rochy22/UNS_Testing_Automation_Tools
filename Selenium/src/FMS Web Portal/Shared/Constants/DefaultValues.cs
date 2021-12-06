using System;

namespace FMSWebPortal.Shared.Constants.DefaultValues
{
    public static class DefaultValues
    {
        public const int SizeDoubleField = 100;
        public const int SizeField = 50;
        public const int SizeGrid = 20;
        public const int SizeMin = 10;
        public const int SizeTextArea = 2000;
        public const int UnitedStatesCountryId = 236;
        public const string City = "CityAutomated";
        public const string Country = "United States";
        public const string Create = "Create";
        public const string CssDefault = "core-qa-automation css";
        public const string CurrentlySelected = "Currently Selected: ";
        public const string Disable = "Disable";
        public const string DisplayName = "-,().'_ ";
        public const string Edit = "Edit";
        public const string Email = "!#$%&'*+=?^_`{|}~";
        public const string EmailDomainPart = "@mailinator.com";
        public const string FieldValidationValid = "field-validation-valid";
        public const string FirstName = "First Name";
        public const string Fms = "FMS";
        public const string Greetings = "Welcome to the FMS Web Portal,";
        public const string History = "History";
        public const string InvalidCharacters = "~`!#$%^&[{]}|;\'\"<>?";
        public const string InvalidPassword = "invalid_password";
        public const string InvalidPhoneNumber = "~`!#$%^&[{]}|;\'\"<>?_:,=@*/\\";
        public const string InvalidUsername = "invalid_password";
        public const string JustNow = "just now";
        public const string LastName = "Last Name";
        public const string LastReportOn = "Last Report On";
        public const string Locations = "Locations";
        public const string Lowercase = "abcdefghijkmnopqrstuvwxyz";
        public const string LowercaseAccentedCharacters = "äëïöüâêîôûáéíóúàèìùò";
        public const string Name = "'+.- ";
        public const string NoChangesSelectedRecord = "No changes were performed to the selected record";
        public const string None = "NONE";
        public const string NoResultsFound = "No results found";
        public const string NumericDigit = "0123456789";
        public const string Organization = "core_qa_organization_01";
        public const string Phone = "-.+()";
        public const string PleaseSelectOne = "Please select one...";
        public const string PleaseSelectOrganization = "Please select organization";
        public static string PreferredTimezone = DateTime.UtcNow.IsDaylightSavingTime() ? "(-08:00)" : "(-07:00)";
        public static string PreferredTimezoneTable = "(-08:00)";
        public const string ProductInformation = "Product Information";
        public const string ProductKeys = "Product Keys";
        public const string ProductKeysDeliveryHistory = "Product Keys Delivery History";
        public const string PsDefault = "core-qa-automation ps";
        public const string Rp7 = "RP-7";
        public const string Searching = "Searching...";
        public const string Sip = "SIP";
        public const string State = "California";
        public const string Status = "Status";
        public const string StaffMembers = "Staff Members";
        public const string TextColorDisable = "(187, 187, 187, 1)";
        public const string TextColorEnable = "(51, 51, 51, 1)";
        public const string Timezone = "(UTC-08:00) Pacific Time (US & Canada)";
        public const string TimezoneFormat = "M/d/yyyy H:mm:ss";
        public const string TimezoneTwo = "(UTC-03:00) City of Buenos Aires";
        public const string TimezoneUser = "Pacific Standard Time";
        public static string Today = DateTime.Today.ToString("M/d/yyyy");
        public static string Tomorrow = DateTime.Today.AddDays(1).ToString("M/d/yyyy");
        public static string Yesterday = DateTime.Today.AddDays(-1).ToString("M/d/yyyy");
        public const string Unknown = "Unknown";
        public const string Update = "Update";
        public const string Uppercase = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
        public const string UppercaseAccentedCharacters = "ÄËÏÖÜÂÊÎÔÛÁÉÍÓÚÀÈÌÒÙ";
        public const string Username = "-._";
        public const string ValidCharacters = "_-():.,+=@*/\\;";
        public const string WebRTC = "WebRTC";
        public const string ZipCode = "ZipAutomated";

        public static string HasBeenSaved(string name) => $"The record: \"{name}\" has been saved";

        public static string NoChanges(string record) => $"No changes were made for record \"{record}";

        public static string SavedMessage(string name) => $"The record: \"{name}\" has been saved";
    }
}
