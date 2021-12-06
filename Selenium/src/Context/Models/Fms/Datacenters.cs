using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Datacenters), Schema = Schemas.Fms)]
    public partial class Datacenters
    {
        [Key]
        public int DatacenterId { get; set; }

        public string IpAddress { get; set; }

        public string Name { get; set; }
    }
}
