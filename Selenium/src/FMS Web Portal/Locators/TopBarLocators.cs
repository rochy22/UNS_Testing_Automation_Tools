using Common.Classes;
using OpenQA.Selenium;

namespace FMSWebPortal.Locators
{
    public class TopBarLocators : BasePageLocator
    {
        public IWebElement Access => Driver.FindElement(By.CssSelector("a[href='/Menu/Access']"));

        public IWebElement AccessMaps => Driver.FindElement(By.CssSelector("a[href = '/AccessMap']"));

        public IWebElement AccessRules => Driver.FindElement(By.CssSelector("a[href='/ConnectivityRule']"));

        public IWebElement AddSurvey => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/FmsAddSurvey']"));

        public IWebElement AdvancedLogging => Driver.FindElement(By.CssSelector("a[href='/Menu/AdvancedLogging']"));

        public IWebElement Applications => Driver.FindElement(By.CssSelector("a[href='/Application']"));

        public IWebElement AuthenticationLogs => Driver.FindElement(By.CssSelector("a[href='/AuthenticationLog']"));

        public IWebElement BandwidthStats => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/BandwidthStats']"));

        public IWebElement BandwidthTestResults => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/BandwidthTestResults']"));

        public IWebElement BiReports => Driver.FindElement(By.CssSelector("a[href='/BIReport']"));

        public IWebElement CallDetailRecords => Driver.FindElement(By.CssSelector("a[href='/CallDetailRecord']"));

        public IWebElement CareLocationHistory => Driver.FindElement(By.CssSelector("a[href='/ProductCareLocationHistory']"));

        public IWebElement CareLocations => Driver.FindElement(By.CssSelector("a[href='/CareLocation']"));

        public IWebElement CareLocationsByAccount => Driver.FindElement(By.CssSelector("a[href='/CareLocationByAccount']"));

        public IWebElement CareLocationsGroups => Driver.FindElement(By.CssSelector("a[href='/CareLocationsGroups']"));

        public IWebElement CareLocationTypes => Driver.FindElement(By.CssSelector("a[href='/CareLocationType']"));

        public IWebElement ChangePassword => Driver.FindElement(By.CssSelector("a[href='/Account/ChangePassword']"));

        public IWebElement ConnectivityGroups => Driver.FindElement(By.CssSelector("a[href='/ConnectivityGroup']"));

        public IWebElement ConnectivityRuleHistory => Driver.FindElement(By.CssSelector("a[href='/ConnectivityRuleHistory']"));

        public IWebElement CopyFromCareLocation => Driver.FindElement(By.CssSelector("a[href='/CopyFromCareLocation']"));

        public IWebElement CopyFromUser => Driver.FindElement(By.CssSelector("a[href='/Copy/Users']"));

        public IWebElement Dashboard => Driver.FindElement(By.CssSelector("a[href='/Dashboard']"));

        public IWebElement Deactivations => Driver.FindElement(By.CssSelector("a[href='/Deactivation']"));

        public IWebElement DetailedStatus => Driver.FindElement(By.CssSelector("a[href='/RpEndpointStatusDetail/StatusDetailed']"));

        public IWebElement EditSurvey => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/FmsEditSurvey']"));

        public IWebElement Events => Driver.FindElement(By.CssSelector("a[href='/Event']"));

        public IWebElement EventsWhitelist => Driver.FindElement(By.CssSelector("a[href='/Whitelist']"));

        public IWebElement Fleet => Driver.FindElement(By.CssSelector("a[href='/Menu/Fleet']"));

        public IWebElement Gateways => Driver.FindElement(By.CssSelector("a[href='/Gateway']"));

        public IWebElement HealthcareApplicationUrls => Driver.FindElement(By.CssSelector("a[href='/HealthcareAppUrl']"));

        public IWebElement History => Driver.FindElement(By.CssSelector("a[href='/Dashboard/History']"));

        public IWebElement Home => Driver.FindElement(By.CssSelector("a[href='/']"));

        public IWebElement HumanUsers => Driver.FindElement(By.CssSelector("a[href='/HumanUser']"));

        public IWebElement HumanUsersByAccount => Driver.FindElement(By.CssSelector("a[href='/HumanUserByAccount']"));

        public IWebElement IntouchAlerts => Driver.FindElement(By.CssSelector("a[href='/Menu/Alerts']"));

        public IWebElement IntouchDevicesStatus => Driver.FindElement(By.CssSelector("a[href='/RpEndpointStatus']"));

        public IWebElement Locations => Driver.FindElement(By.CssSelector("a[href='/Location']"));

        public IWebElement Logout => Driver.FindElement(By.CssSelector("a[href='/Account/LogOut']"));

        public IWebElement LogViewer => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/LogViewer']"));

        public IWebElement LogViewerIos => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/LogViewerIos']"));

        public IWebElement MachineUsers => Driver.FindElement(By.CssSelector("a[href='/MachineUser']"));

        public IWebElement MainTitle => Driver.FindElement(By.CssSelector("div[class='mainTitle']"));

        public IWebElement MyAccount => Driver.FindElement(By.CssSelector("a[href='/Menu/Account']"));

        public IWebElement Organizations => Driver.FindElement(By.CssSelector("a[href='/Organization']"));

        public IWebElement Presences => Driver.FindElement(By.CssSelector("a[href='/Presence']"));

        public IWebElement PresencesHistory => Driver.FindElement(By.CssSelector("a[href='/Presence/History']"));

        public IWebElement ProductKeys => Driver.FindElement(By.CssSelector("a[href='/ProductKey']"));

        public IWebElement Products => Driver.FindElement(By.CssSelector("a[href='/Product']"));

        public IWebElement ProductTypes => Driver.FindElement(By.CssSelector("a[href='/ProductType']"));

        public IWebElement Programs => Driver.FindElement(By.CssSelector("a[href='/Program']"));

        public IWebElement ProgramTypes => Driver.FindElement(By.CssSelector("a[href='/ProgramType']"));

        public IWebElement ProviderAccessStatus => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/FmsProviderAccessStatus']"));

        public IWebElement Registrations => Driver.FindElement(By.CssSelector("a[href='/Registration']"));

        public IWebElement ReleaseNotes => Driver.FindElement(By.CssSelector("a[href='/Document/View/2']"));

        public IWebElement RroductManagement => Driver.FindElement(By.CssSelector("a[href='/Menu/ProductManagement']"));

        public IWebElement Search => Driver.FindElement(By.CssSelector("a[href='/Search']"));

        public IWebElement Servers => Driver.FindElement(By.CssSelector("a[href='/Server']"));

        public IWebElement ServiceReachabilityHistory => Driver.FindElement(By.CssSelector("a[href='/ServiceReachabilityHistory']"));

        public IWebElement SessionViewer => Driver.FindElement(By.CssSelector("a[href='/Fms1Link/SessionViewer']"));

        public IWebElement Settings => Driver.FindElement(By.CssSelector("a[href='/Account/Settings']"));

        public IWebElement Sip => Driver.FindElement(By.CssSelector("a[href='/Menu/Sip']"));

        public IWebElement SoftwarePackages => Driver.FindElement(By.CssSelector("a[href='/SoftwarePackage']"));

        public IWebElement Specialties => Driver.FindElement(By.CssSelector("a[href='/Specialty']"));

        public IWebElement StaffMembers => Driver.FindElement(By.CssSelector("a[href='/StaffMember']"));

        public IWebElement Suresupport => Driver.FindElement(By.CssSelector("a[href='/Menu/SureSupport']"));

        public IWebElement Swap => Driver.FindElement(By.CssSelector("a[href='/ProductSwap/Swap']"));

        public IWebElement Synchronization => Driver.FindElement(By.CssSelector("a[href='/SipSynchronization']"));

        public IWebElement UnconfirmedUsers => Driver.FindElement(By.CssSelector("a[href='/RegisteredUsersConfiguration']"));

        public IWebElement UserActivity => Driver.FindElement(By.CssSelector("a[href='/UserActivity']"));

        public IWebElement UserGuide => Driver.FindElement(By.CssSelector("a[href='/Document/View/1']"));

        public IWebElement Users => Driver.FindElement(By.CssSelector("a[href='/Menu/Users']"));

        public IWebElement UsersGroups => Driver.FindElement(By.CssSelector("a[href='/UsersGroup']"));

        public IWebElement WebServicesPosts => Driver.FindElement(By.CssSelector("a[href='/ServicePost']"));
    }
}
