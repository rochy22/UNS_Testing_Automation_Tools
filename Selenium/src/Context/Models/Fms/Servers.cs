using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Servers), Schema = Schemas.Fms)]
    public partial class Servers
    {
        [Key]
        public long ServerId { get; set; }

        public int DatacenterId { get; set; }

        public string DnsName { get; set; }

        public string IpAddress { get; set; }

        public bool IsEnabled { get; set; }

        public string Name { get; set; }

        public byte ServerTypeId { get; set; }

        public Datacenters Datacenter { get; set; }
    }
}