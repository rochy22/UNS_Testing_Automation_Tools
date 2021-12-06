using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(CareLocationsGroups), Schema = Schemas.Fms)]
    public partial class CareLocationsGroups
    {
        public CareLocationsGroups() { }

        [Key]
        public long CareLocationsGroupId { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
