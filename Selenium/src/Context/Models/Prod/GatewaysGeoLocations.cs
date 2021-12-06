using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(GatewaysGeoLocations), Schema = Schemas.Prod)]
    public partial class GatewaysGeoLocations
    {
        [Key]
        public long GatewayId { get; set; }

        [Key]
        public long GeoLocationId { get; set; }

        public Gateways Gateway { get; set; }
    }
}