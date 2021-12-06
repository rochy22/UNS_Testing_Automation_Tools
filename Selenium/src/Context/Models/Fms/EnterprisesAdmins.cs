using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(EnterprisesAdmins), Schema = Schemas.Fms)]
    public partial class EnterprisesAdmins
    {
        [Key]
        public Guid EnterpriseId { get; set; }

        [Key]
        public Guid UserId { get; set; }

        public Enterprises Enterprise { get; set; }

        public Users Admin { get; set; }
    }
}
