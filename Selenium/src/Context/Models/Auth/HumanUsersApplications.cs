using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(HumanUsersApplications), Schema = Schemas.Auth)]
    public partial class HumanUsersApplications
    {
        [Key]
        public Guid UserId { get; set; }

        [Key]
        public int ApplicationId { get; set; }

        public Applications Application { get; set; }
    }
}
