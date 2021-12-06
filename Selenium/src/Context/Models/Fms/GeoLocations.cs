using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(GeoLocations), Schema = Schemas.Fms)]
    public partial class GeoLocations
    {
        [Key]
        public long GeoLocationId { get; set; }

        public string ModifiedBy { get; set; }

        public string Name { get; set; }

        public Guid? OrganizationId { get; set; }

        public int TimezoneId { get; set; }

        public ICollection<CareLocations> CareLocations { get; set; }

        public ICollection<GatewaysGeoLocations> GatewaysGeoLocations { get; set; }

        public Organizations Organization { get; set; }
    }
}
