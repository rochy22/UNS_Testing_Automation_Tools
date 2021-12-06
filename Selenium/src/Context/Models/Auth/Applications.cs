using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Applications), Schema = Schemas.Auth)]
    public partial class Applications
    {
        [Key]
        public int ApplicationId { get; set; }

        public string Name { get; set; }
    }
}
