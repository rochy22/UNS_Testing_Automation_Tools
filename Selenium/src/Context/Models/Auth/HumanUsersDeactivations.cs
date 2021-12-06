using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(HumanUsersDeactivations), Schema = Schemas.Auth)]
    public partial class HumanUsersDeactivations
    {
        [Key]
        public int DeactivationId { get; set; }

        public string Comments { get; set; }

        public Guid DeactivatedBy { get; set; }

        public DateTime DeactivationDate { get; set; }

        public Guid UserId { get; set; }
    }
}
