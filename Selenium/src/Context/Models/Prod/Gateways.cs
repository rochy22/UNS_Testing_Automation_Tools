using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Gateways), Schema = Schemas.Prod)]
    public partial class Gateways
    {
        [Key]
        public long GatewayId { get; set; }

        public long Serial { get; set; }
    }
}
