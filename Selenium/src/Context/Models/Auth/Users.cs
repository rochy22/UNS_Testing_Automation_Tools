using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;
using FmsDbContext.Utils;

namespace FmsDbContext
{
    [Table(nameof(Users), Schema = Schemas.Auth)]
    public partial class Users
    {
        [Key]
        public Guid UserId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Use this property to get or set the plain value of the column Password from the database.
        /// </summary>
        [NotMapped]
        public string DecryptedPassword
        {
            get => Password is null ? null : EncoderDecoder.DecryptAes256(Password, AppSettingsProvider.DbEncryptionKey);
            set { Password = value is null ? null : EncoderDecoder.EncryptAes256(value, AppSettingsProvider.DbEncryptionKey); }
        }

        public string HashedPassword { get; set; }

        public bool IsEnabledForSip { get; set; }

        /// <summary>
        /// This property holds the encrypted data, it must not be used to get or set the values of Password.
        /// </summary>
        public string Password { get; set; }

        public DateTime? PasswordLastResetDate { get; set; }

        public long? SipSettingsId { get; set; }

        public string Username { get; set; }

        public byte UserType { get; set; }

        public ICollection<ConnectivityRules> ConnectivityRulesFromUserNavigation { get; set; }

        public HumanUsers HumanUsers { get; set; }

        [InverseProperty(nameof(FmsDbContext.RpDeviceUsers.User))]
        public RpDeviceUsers RpDeviceUsers { get; set; }

        public SipSettings SipSettings { get; set; }

        public ICollection<CareLocationsAdmins> CareLocationsAdmins { get; set; }

        public EnterprisesAdmins EnterprisesAdmins { get; set; }
    }
}
