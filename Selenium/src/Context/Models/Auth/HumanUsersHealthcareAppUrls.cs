using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(HumanUsersHealthcareAppUrls), Schema = Schemas.Auth)]
    public partial class HumanUsersHealthcareAppUrls
    {
        [Key]
        public long HumanUsersHealthcareAppUrlId { get; set; }

        public long HealthcareAppUrlId { get; set; }

        public bool IsDefault { get; set; }

        public Guid UserId { get; set; }
    }
}
