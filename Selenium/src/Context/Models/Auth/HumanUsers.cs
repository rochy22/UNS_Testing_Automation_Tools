using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;
using FmsDbContext.Utils;

namespace FmsDbContext
{
    [Table(nameof(HumanUsers), Schema = Schemas.Auth)]
    public partial class HumanUsers : IEquatable<HumanUsers>
    {
        public HumanUsers()
        {
            PreferredTimezone = "Pacific Standard Time";
            UsersGroupId = 1;
            ConnectivityGroupId = 311;
        }

        [Key]
        public Guid UserId { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// This property holds the encrypted data, it must not be used to get or set the values of AnswerOne.
        /// </summary>
        public string AnswerOne { get; set; }

        /// <summary>
        /// This property holds the encrypted data, it must not be used to get or set the values of AnswerTwo.
        /// </summary>
        public string AnswerTwo { get; set; }

        public int? ChallengeQuestionId { get; set; }

        public int? ChallengeQuestionTwoId { get; set; }

        public string City { get; set; }

        public string Comments { get; set; }

        public long ConnectivityGroupId { get; set; }

        public int? CountryId { get; set; }

        /// <summary>
        /// Use this property to get or set the plain value of the column AnswerOne from the database.
        /// </summary>
        [NotMapped]
        public string DecryptedAnswerOne
        {
            get => AnswerOne is null ? null : EncoderDecoder.DecryptAes256(AnswerOne, AppSettingsProvider.DbEncryptionKey);
            set { AnswerOne = value is null ? null : EncoderDecoder.EncryptAes256(value, AppSettingsProvider.DbEncryptionKey); }
        }

        /// <summary>
        /// Use this property to get or set the plain value of the column AnswerTwo from the database.
        /// </summary>
        [NotMapped]
        public string DecryptedAnswerTwo
        {
            get => AnswerTwo is null ? null : EncoderDecoder.DecryptAes256(AnswerTwo, AppSettingsProvider.DbEncryptionKey);
            set { AnswerTwo = value is null ? null : EncoderDecoder.EncryptAes256(value, AppSettingsProvider.DbEncryptionKey); }
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Employer { get; set; }

        public byte? EnterpriseId { get; set; }

        public string EpicEmpId { get; set; }

        public string FirstName { get; set; }

        public bool IsEmployee { get; set; }

        public bool IsEnabled { get; set; }

        public string LastName { get; set; }

        public long? NationalProviderIdentifier { get; set; }

        public string Mobile { get; set; }

        public string ModifiedBy { get; set; }

        public string OfficePhone { get; set; }

        public Guid? OrganizationLicenseId { get; set; }

        public Guid? OrganizationProviderId { get; set; }

        public string PreferredTimezone { get; set; }

        public string ServiceLine { get; set; }

        public int? SpecialtyId { get; set; }

        public int? StateId { get; set; }

        public string Title { get; set; }

        public long UsersGroupId { get; set; }

        public string Zip { get; set; }

        public ChallengeQuestions ChallengeQuestion { get; set; }

        public ChallengeQuestions ChallengeQuestionTwo { get; set; }

        public ICollection<HumanUsersApplications> HumanUsersApplications { get; set; }

        public ICollection<HumanUsersHealthcareAppUrls> HumanUsersHealthcareAppUrls { get; set; }

        public Organizations OrganizationProvider { get; set; }

        public ICollection<OrganizationsAdmins> OrganizationsAdmins { get; set; }

        public Specialties Specialty { get; set; }

        public Users User { get; set; }

        public bool Equals(HumanUsers other) => other != null &&
                   UserId.Equals(other.UserId) &&
                   Address == other.Address &&
                   City == other.City &&
                   Comments == other.Comments &&
                   ConnectivityGroupId == other.ConnectivityGroupId &&
                   CountryId == other.CountryId &&
                   Email == other.Email &&
                   Email2 == other.Email2 &&
                   Employer == other.Employer &&
                   EnterpriseId == other.EnterpriseId &&
                   EpicEmpId == other.EpicEmpId &&
                   FirstName == other.FirstName &&
                   IsEnabled == other.IsEnabled &&
                   LastName == other.LastName &&
                   NationalProviderIdentifier == other.NationalProviderIdentifier &&
                   Mobile == other.Mobile &&
                   OfficePhone == other.OfficePhone &&
                   EqualityComparer<Guid?>.Default.Equals(OrganizationLicenseId, other.OrganizationLicenseId) &&
                   EqualityComparer<Guid?>.Default.Equals(OrganizationProviderId, other.OrganizationProviderId) &&
                   PreferredTimezone == other.PreferredTimezone &&
                   ServiceLine == other.ServiceLine &&
                   SpecialtyId == other.SpecialtyId &&
                   StateId == other.StateId &&
                   Title == other.Title &&
                   UsersGroupId == other.UsersGroupId &&
                   Zip == other.Zip &&
                   EqualityComparer<ICollection<HumanUsersApplications>>.Default.Equals(HumanUsersApplications, other.HumanUsersApplications) &&
                   EqualityComparer<ICollection<HumanUsersHealthcareAppUrls>>.Default.Equals(HumanUsersHealthcareAppUrls, other.HumanUsersHealthcareAppUrls) &&
                   EqualityComparer<Organizations>.Default.Equals(OrganizationProvider, other.OrganizationProvider) &&
                   EqualityComparer<ICollection<OrganizationsAdmins>>.Default.Equals(OrganizationsAdmins, other.OrganizationsAdmins) &&
                   EqualityComparer<Specialties>.Default.Equals(Specialty, other.Specialty);
    }
}
