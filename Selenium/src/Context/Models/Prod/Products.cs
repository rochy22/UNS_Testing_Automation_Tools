using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Products), Schema = Schemas.Prod)]
    public partial class Products
    {
        public Products()
        {
            ProductKeys = new HashSet<ProductKeys>();
        }

        [Key]
        public long ProductId { get; set; }

        public long CareLocationId { get; set; }

        public int IsActive { get; set; }

        public long? Serial { get; set; }

        public int SubtypeId { get; set; }

        public CareLocations CareLocation { get; set; }

        public RpDeviceUsers RpDeviceUsers { get; set; }

        public Subtypes Subtype { get; set; }

        public IEnumerable<ProductKeys> ProductKeys { get; set; }
    }
}
