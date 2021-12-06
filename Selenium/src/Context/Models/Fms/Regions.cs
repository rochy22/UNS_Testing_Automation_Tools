using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table("Regions", Schema = Schemas.Fms)]
    public partial class Regions
    {
        public Regions() { }

        [Key]
        public long RegionId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<CareLocations> CareLocations { get; set; }

        public ICollection<States> States { get; set; }
    }
}
