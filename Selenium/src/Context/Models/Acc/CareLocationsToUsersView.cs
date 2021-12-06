using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(CareLocationsToUsersView), Schema = Schemas.Acc)]
    public partial class CareLocationsToUsersView
    {
        [Key]
        public long CareLocationId { get; set; }

        [Key]
        public Guid ToUserId { get; set; }
    }
}
