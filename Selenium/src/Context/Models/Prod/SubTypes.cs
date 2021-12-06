using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Subtypes), Schema = Schemas.Prod)]
    public partial class Subtypes
    {
        [Key]
        public int SubtypeId { get; set; }

        public int TypeId { get; set; }

        public Types Type { get; set; }
    }
}
