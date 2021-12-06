using System;
using Xunit;

namespace FMSWebPortal.Models
{
    public class HumanUser
    {
        public HumanUser() { }

        public long Id { get; set; }

        public string Username { get; set; }

        public string Address { get; set; }

        public string AlternativeEmail { get; set; }

        public string ChallengeAnswer { get; set; }

        public string ChallengeAnswerTwo { get; set; }

        public string ChallengeQuestion { get; set; }

        public string ChallengeQuestionTwo { get; set; }

        public string City { get; set; }

        public string Comments { get; set; }

        public string ConnectivityGroup { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Employer { get; set; }

        public string EpicEmpId { get; set; }

        public string ExternalProvider { get; set; }

        public string FirstName { get; set; }

        public bool IsEmployee { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Npi { get; set; }

        public string OfficePhone { get; set; }

        public string OrganizationLicense { get; set; }

        public string OrganizationProvider { get; set; }

        public string PreferredTimezone { get; set; }

        public string ServiceLine { get; set; }

        public string SoloLicense { get; set; }

        public string Specialty { get; set; }

        public string State { get; set; }

        public string Title { get; set; }

        public string UserGroup { get; set; }

        public string Zip { get; set; }

        public override bool Equals(object obj)
        {
            var user = (HumanUser)obj;

            Assert.Equal(user.Id, Id);
            Assert.Equal(user.Username, Username);
            Assert.Equal(user.Address, Address);
            Assert.Equal(user.AlternativeEmail, AlternativeEmail);
            Assert.Equal(user.ChallengeAnswer, ChallengeAnswer);
            Assert.Equal(user.ChallengeAnswerTwo, ChallengeAnswerTwo);
            Assert.Equal(user.ChallengeQuestion, ChallengeQuestion);
            Assert.Equal(user.ChallengeQuestionTwo, ChallengeQuestionTwo);
            Assert.Equal(user.City, City);
            Assert.Equal(user.Comments, Comments);
            Assert.Equal(user.ConnectivityGroup, ConnectivityGroup);
            Assert.Equal(user.Country, Country);
            Assert.Equal(user.Email, Email);
            Assert.Equal(user.Employer, Employer);
            Assert.Equal(user.EpicEmpId, EpicEmpId);
            Assert.Equal(user.ExternalProvider, ExternalProvider);
            Assert.Equal(user.FirstName, FirstName);
            Assert.Equal(user.IsEmployee, IsEmployee);
            Assert.Equal(user.LastName, LastName);
            Assert.Equal(user.Mobile, Mobile);
            Assert.Equal(user.Npi, Npi);
            Assert.Equal(user.OfficePhone, OfficePhone);
            Assert.Equal(user.OrganizationLicense, OrganizationLicense);
            Assert.Equal(user.OrganizationProvider, OrganizationProvider);
            Assert.Equal(user.PreferredTimezone, PreferredTimezone);
            Assert.Equal(user.ServiceLine, ServiceLine);
            Assert.Equal(user.SoloLicense, SoloLicense);
            Assert.Equal(user.Specialty, Specialty);
            Assert.Equal(user.State, State);
            Assert.Equal(user.Title, Title);
            Assert.Equal(user.UserGroup.Equals("No Users Group") ? "" : user.UserGroup, UserGroup);
            Assert.Equal(user.Zip, Zip);

            return true;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(Username);
            hash.Add(Address);
            hash.Add(AlternativeEmail);
            hash.Add(ChallengeAnswer);
            hash.Add(ChallengeAnswerTwo);
            hash.Add(ChallengeQuestion);
            hash.Add(ChallengeQuestionTwo);
            hash.Add(City);
            hash.Add(Comments);
            hash.Add(ConnectivityGroup);
            hash.Add(Country);
            hash.Add(Email);
            hash.Add(Employer);
            hash.Add(EpicEmpId);
            hash.Add(ExternalProvider);
            hash.Add(FirstName);
            hash.Add(IsEmployee);
            hash.Add(LastName);
            hash.Add(Mobile);
            hash.Add(Npi);
            hash.Add(OfficePhone);
            hash.Add(OrganizationLicense);
            hash.Add(OrganizationProvider);
            hash.Add(PreferredTimezone);
            hash.Add(ServiceLine);
            hash.Add(SoloLicense);
            hash.Add(Specialty);
            hash.Add(State);
            hash.Add(Title);
            hash.Add(UserGroup);
            hash.Add(Zip);
            return hash.ToHashCode();
        }
    }
}
