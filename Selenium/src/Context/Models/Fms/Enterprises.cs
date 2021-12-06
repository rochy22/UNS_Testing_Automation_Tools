using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Enterprises), Schema = Schemas.Fms)]
    public partial class Enterprises
    {
        [Key]
        public Guid EnterpriseId { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }

        public ICollection<Organizations> Organizations { get; set; }

        public ICollection<EnterprisesAdmins> EnterprisesAdmins { get; set; }
    }
}
