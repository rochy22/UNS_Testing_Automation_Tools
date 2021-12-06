using System.Linq;
using FMSWebPortal.Models;
using FMSWebPortal.Shared;
using FMSWebPortal.Shared.Constants.ConnectivityGroupValues;
using FMSWebPortal.Shared.Constants.DefaultValues;
using FMSWebPortal.Shared.Constants.HumanUsersValues;
using Microsoft.EntityFrameworkCore;

namespace FMSWebPortal.Helpers.Users
{
    class UsersHelper
    {
        public static HumanUser CreateBody(bool withOptionals = false)
        {
            var user = HumanUsersValues.Prefix + RandomHelper.RandomString(5, digit: true, lowercase: true);

            var hu = new HumanUser
            {
                Username = user,
                FirstName = DefaultValues.FirstName.Replace(" ", ""),
                LastName = DefaultValues.LastName.Replace(" ", ""),
                Email = user + DefaultValues.EmailDomainPart,
                ConnectivityGroup = ConnectivityGroupValues.Prefix + "01"
            };

            if (withOptionals)
            {
                hu.Address = HumanUsersValues.Address;
                hu.ChallengeAnswer = HumanUsersValues.ChallengeAnswer;
                hu.ChallengeAnswerTwo = HumanUsersValues.ChallengeAnswer;
                hu.ChallengeQuestion = HumanUsersValues.ChallengeQuestion;
                hu.ChallengeQuestionTwo = HumanUsersValues.ChallengeQuestionTwo;
                hu.City = DefaultValues.City;
                hu.Comments = RandomHelper.RandomString(10, alphabeticalWithSymbols: true);
                hu.Country = DefaultValues.Country;
                hu.AlternativeEmail = RandomHelper.GenerateEmail();
                hu.Employer = RandomHelper.RandomString(10, alphabeticalWithSymbols: true);
                hu.Mobile = HumanUsersValues.Phone;
                hu.OfficePhone = HumanUsersValues.Phone;
                hu.ServiceLine = RandomHelper.RandomString(10, alphabeticalWithSymbols: true);
                hu.Specialty = HumanUsersValues.SpecialtyEnabled;
                hu.State = DefaultValues.State;
                hu.Title = RandomHelper.RandomString(10, alphabeticalWithSymbols: true);
                hu.Zip = DefaultValues.ZipCode;
                hu.UserGroup = HumanUsersValues.PrefixUserGroup;
                hu.OrganizationLicense = DefaultValues.Organization;
                hu.OrganizationProvider = DefaultValues.Organization;
                hu.Npi = HumanUsersValues.ValidNpi;
                hu.PreferredTimezone = DefaultValues.Timezone;
                hu.IsEmployee = true;
                hu.EpicEmpId = RandomHelper.RandomString(10, alphabeticalWithSymbols: true);
            }

            return hu;
        }

        public static FmsDbContext.ConnectivityGroups ConnectivityGroupByName(string name)
        {
            using var context = FmsContextHelper.CreateFmsContext();

            return context.ConnectivityGroups.FirstOrDefault(cl => cl.Name == name);
        }

        public static FmsDbContext.Countries ContryByName(string name)
        {
            using var context = FmsContextHelper.CreateFmsContext();

            return context.Countries.FirstOrDefault(c => c.Name == name);
        }

        public static FmsDbContext.Specialties SpecialtyByName(string name)
        {
            using var context = FmsContextHelper.CreateFmsContext();

            return context.Specialties.FirstOrDefault(c => c.Name == name);
        }

        public static string SpecialtyName(bool robotPipEnabled)
        {
            using var context = FmsContextHelper.CreateFmsContext();

            return context.Specialties.FirstOrDefault(c => c.RobotPipEnabled == robotPipEnabled).Name;
        }

        public static FmsDbContext.Users GetByUsername(string username)
        {
            using var context = FmsContextHelper.CreateFmsContext();

            return context.Users.FirstOrDefault(hu => hu.Username.Equals(username));
        }

        public static FmsDbContext.Users GetRandomEnterpriseUser()
        {
            using var context = FmsContextHelper.CreateFmsContext();

            var humanUser = context.HumanUsers.Include(hu => hu.User)
                        .LastOrDefault(hu => hu.EnterpriseId != null
                                            && hu.IsEnabled
                                            && hu.User.UserType == 0);

            return humanUser.User;
        }

    }
}
