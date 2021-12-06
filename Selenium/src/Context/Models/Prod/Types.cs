using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Types), Schema = Schemas.Prod)]
    public partial class Types
    {
        [Key]
        public int TypeId { get; set; }

        public byte ProductCategory { get; set; }
    }
}
