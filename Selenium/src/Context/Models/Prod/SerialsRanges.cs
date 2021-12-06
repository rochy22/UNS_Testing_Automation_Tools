using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(SerialsRanges), Schema = Schemas.Prod)]
    public partial class SerialsRanges
    {
        [Key]
        public int SerialRangeId { get; set; }

        public long LastUsed { get; set; }
    }
}
