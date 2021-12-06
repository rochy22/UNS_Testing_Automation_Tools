using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(RpDeviceUsers), Schema = Schemas.Auth)]
    public partial class RpDeviceUsers
    {
        [Key]
        public Guid UserId { get; set; }

        public long ProductId { get; set; }

        public Products Product { get; set; }

        [InverseProperty(nameof(Users.RpDeviceUsers))]
        public Users User { get; set; }

    }
}
