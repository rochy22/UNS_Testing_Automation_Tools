using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(UnconfirmedUsers), Schema = Schemas.Auth)]
    public partial class UnconfirmedUsers
    {
        [Key]
        public long UnconfirmedUserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
