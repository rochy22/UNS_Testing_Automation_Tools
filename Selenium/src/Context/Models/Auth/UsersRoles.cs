using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(UsersRoles), Schema = Schemas.Auth)]
    public partial class UsersRoles
    {
        [Key]
        public int RoleId { get; set; }

        [Key]
        public Guid UserId { get; set; }

        public ApplicationRoles Role { get; set; }
    }
}
