using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ConnectivityRulesHistory), Schema = Schemas.Sip)]
    public partial class ConnectivityRulesHistory
    {
        [Key]
        public Guid ConnectivityId { get; set; }

        public string Action { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid FromUser { get; set; }

        public DateTime ModificationDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime StartDate { get; set; }

        public Guid ToUser { get; set; }
    }
}
