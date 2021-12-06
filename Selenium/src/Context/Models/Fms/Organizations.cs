using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Organizations), Schema = Schemas.Fms)]
    public partial class Organizations
    {
        [Key]
        public Guid OrganizationId { get; set; }

        public bool Enabled { get; set; }

        public Guid? EnabledBy { get; set; }

        public DateTime? EnabledOn { get; set; }

        public string SfName { get; set; }

        public string SfAccountId { get; set; }

        public int? SfGpCustomerNumber { get; set; }

        public string SfShippingCity { get; set; }

        public string SfShippingCountry { get; set; }

        public string SfShippingPostalCode { get; set; }

        public string SfShippingState { get; set; }

        public string SfShippingStreet { get; set; }

        public bool SoloTheme { get; set; }

        public Enterprises Enterprise { get; set; }

        public virtual Guid? EnterpriseId { get; set; }
    }
}
