using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ConnectivityRulesView), Schema = Schemas.Admin)]
    public class ConnectivityRulesView
    {
        [Key]
        public Guid ConnectivityRuleId { get; set; }

        public long CareLocationId { get; set; }

        public string CareLocationName { get; set; }

        public Guid CareLocationOrganizationId { get; set; }

        public string Email { get; set; }

        public DateTime? EndDate { get; set; }

        public string FirstName { get; set; }

        public bool HumanUserIsEnabled { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public Guid UserOrganizationId { get; set; }
    }
}
