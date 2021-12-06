using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(OrganizationsAdmins), Schema = Schemas.Fms)]
    public class OrganizationsAdmins
    {
        [Key]
        public Guid UserId { get; set; }

        [Key]
        public Guid OrganizationId { get; set; }

        public Organizations Organization { get; set; }
    }
}
