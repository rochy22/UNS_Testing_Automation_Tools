using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ConnectivityRules), Schema = Schemas.Sip)]
    public partial class ConnectivityRules
    {
        [Key]
        public Guid ConnectivityId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid FromUser { get; set; }

        public DateTime? LastModificationDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime StartDate { get; set; }

        public Guid ToUser { get; set; }

        [ForeignKey(nameof(ToUser))]
        public Users ToUserNavigation { get; set; }
    }
}
