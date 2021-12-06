using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ConnectivityGroups), Schema = Schemas.Fms)]
    public partial class ConnectivityGroups
    {
        public ConnectivityGroups() { }

        [Key]
        public long ConnectivityGroupId { get; set; }

        public string Name { get; set; }
    }
}
