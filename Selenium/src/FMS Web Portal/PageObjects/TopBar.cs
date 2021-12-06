using Common.Classes;
using FMSWebPortal.Locators;
using FMSWebPortal.Shared.Constants.DefaultValues;
using FMSWebPortal.Shared.DataHelper;
using Xunit;

namespace FMSWebPortal.PageObjects
{
    public class TopBar : BasePage
    {
        private TopBarLocators _locator;
        private readonly DataHelper _data;

        public TopBar()
        {
            Url = "/";
            _data = new DataHelper();
            _baseUrl = _data.GetBaseUrl();
            _locator = new TopBarLocators();
        }

        public void ClickAccessLink() => _locator.Access.Click();

        public void ClickAccessLink1()
        {
            this._locator.Access.Click();
        }

        public void ClickAccessMapsLink() => _locator.AccessMaps.Click();

        public void ClickAccessRulesLink() => _locator.AccessRules.Click();

        public void ClickAddSurveyLink() => _locator.AddSurvey.Click();

        public void ClickAdvancedLoggingLink() => _locator.AdvancedLogging.Click();

        public void ClickApplicationsLink() => _locator.Applications.Click();

        public void ClickAuthenticationLogsLink() => _locator.AuthenticationLogs.Click();

        public void ClickBandwidthStatsLink() => _locator.BandwidthStats.Click();

        public void ClickBandwidthTestResultsLink() => _locator.BandwidthTestResults.Click();

        public void ClickBiReportsLink() => _locator.BiReports.Click();

        public void ClickCallDetailRecordsLink() => _locator.CallDetailRecords.Click();

        public void ClickCareLocationsLink() => _locator.CareLocations.Click();

        public void ClickChangePasswordLink() => _locator.ChangePassword.Click();

        public void ClickConnectivityGroupsLink() => _locator.ConnectivityGroups.Click();

        public void ClickConnectivityRuleHistoryLink() => _locator.ConnectivityRuleHistory.Click();

        public void ClickCopyFromLocationLink() => _locator.CopyFromCareLocation.Click();

        public void ClickCopyFromUserLink() => _locator.CopyFromUser.Click();

        public void ClickDashboardLink() => _locator.Dashboard.Click();

        public void ClickDeactivationsLink() => _locator.Deactivations.Click();

        public void ClickDetailedStatusLink() => _locator.DetailedStatus.Click();

        public void ClickEditSurveyLink() => _locator.EditSurvey.Click();

        public void ClickEventsLink() => _locator.Events.Click();

        public void ClickEventsWhitelistLink() => _locator.EventsWhitelist.Click();

        public void ClickFleetLink() => _locator.Fleet.Click();

        public void ClickGatewaysLink() => _locator.Gateways.Click();

        public void ClickHealthcareApplicationUrlsLink() => _locator.HealthcareApplicationUrls.Click();

        public void ClickHistoryLink() => _locator.History.Click();

        public void ClickHomeLink() => _locator.Home.Click();

        public void ClickHumanUsersByAccountLink() => _locator.HumanUsersByAccount.Click();

        public void ClickHumanUsersLink() => _locator.HumanUsers.Click();

        public void ClickIntouchAlertsLink() => _locator.IntouchAlerts.Click();

        public void ClickIntouchDevicesStatusLink() => _locator.IntouchDevicesStatus.Click();

        public void ClickLocationHistoryLink() => _locator.CareLocationHistory.Click();

        public void ClickLocationTypesLink() => _locator.CareLocationTypes.Click();

        public void ClickLocationsByAccountLink() => _locator.CareLocationsByAccount.Click();

        public void ClickLocationsGroupsLink() => _locator.CareLocationsGroups.Click();

        public void ClickLocationsLink() => _locator.Locations.Click();

        public void ClickLogViewerIosLink() => _locator.LogViewerIos.Click();

        public void ClickLogViewerLink() => _locator.LogViewer.Click();

        public void ClickLogoutLink() => _locator.Logout.Click();

        public void ClickMachineUsersLink() => _locator.MachineUsers.Click();

        public void ClickMyAccountLink() => _locator.MyAccount.Click();

        public void ClickOrganizationsLink() => _locator.Organizations.Click();

        public void ClickPresencesHistoryLink() => _locator.PresencesHistory.Click();

        public void ClickPresencesLink() => _locator.Presences.Click();

        public void ClickProductKeysLink() => _locator.ProductKeys.Click();

        public void ClickProductManagementLink() => _locator.RroductManagement.Click();

        public void ClickProductTypesLink() => _locator.ProductTypes.Click();

        public void ClickProductsLink() => _locator.Products.Click();

        public void ClickProgramTypesLink() => _locator.ProgramTypes.Click();

        public void ClickProgramsLink() => _locator.Programs.Click();

        public void ClickProviderAccessStatusLink() => _locator.ProviderAccessStatus.Click();

        public void ClickRegistrationsLink() => _locator.Registrations.Click();

        public void ClickReleaseNotesLink() => _locator.ReleaseNotes.Click();

        public void ClickSearchLink() => _locator.Search.Click();

        public void ClickServersLink() => _locator.Servers.Click();

        public void ClickServiceReachabilityHistoryLink() => _locator.ServiceReachabilityHistory.Click();

        public void ClickSessionViewerLink() => _locator.SessionViewer.Click();

        public void ClickSettingsLink() => _locator.Settings.Click();

        public void ClickSipLink() => _locator.Sip.Click();

        public void ClickSoftwarePackagesLink() => _locator.SoftwarePackages.Click();

        public void ClickSpecialtiesLink() => _locator.Specialties.Click();

        public void ClickStaffMembersLink() => _locator.StaffMembers.Click();

        public void ClickSuresupportLink() => _locator.Suresupport.Click();

        public void ClickSwapLink() => _locator.Swap.Click();

        public void ClickSynchronizationLink() => _locator.Synchronization.Click();

        public void ClickUnconfirmedUsersLink() => _locator.UnconfirmedUsers.Click();

        public void ClickUserActivityLink() => _locator.UserActivity.Click();

        public void ClickUserGuideLink() => _locator.UserGuide.Click();

        public void ClickUsersGroupsLink() => _locator.UsersGroups.Click();

        public void ClickUsersLink() => _locator.Users.Click();

        public void ClickWebServicesPostsLink() => _locator.WebServicesPosts.Click();

        public void VerifyPageLoaded()
        {
            var greetingMessage = DefaultValues.Greetings + " " + DefaultValues.FirstName + " " + DefaultValues.LastName;
            Assert.Contains(_locator.MainTitle.Text, greetingMessage);
        }
    }
}