using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Programs), Schema = Schemas.Acc)]
    public partial class Programs
    {
        [Key]
        public long ProgramId { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public string Comments { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid? OrganizationId { get; set; }

        public Organizations Organization { get; set; }

        public ICollection<ProgramsCareLocations> ProgramsCareLocations { get; set; }
    }
}
