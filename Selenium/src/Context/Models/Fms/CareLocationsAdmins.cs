using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(CareLocationsAdmins), Schema = Schemas.Fms)]
    public partial class CareLocationsAdmins
    {
        [Key]
        public long CareLocationId { get; set; }

        [Key]
        public Guid UserId { get; set; }

        public CareLocations CareLocation { get; set; }

        public Users Admin { get; set; }
    }
}
