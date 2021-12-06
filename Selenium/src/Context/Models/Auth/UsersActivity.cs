using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(UsersActivity), Schema = Schemas.Auth)]
    public partial class UsersActivity
    {
        [Key]
        public long UsersActivityId { get; set; }

        public string Action { get; set; }

        public string Details { get; set; }

        public string SubApplication { get; set; }

        public DateTime TimeStamp { get; set; }

        public Guid UserId { get; set; }
    }
}
