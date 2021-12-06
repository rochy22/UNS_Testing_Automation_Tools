using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ProgramsCareLocations), Schema = Schemas.Acc)]
    public partial class ProgramsCareLocations
    {
        [Key]
        public long ProgramId { get; set; }

        public long CareLocationId { get; set; }

        public CareLocations CareLocation { get; set; }

        public Programs Program { get; set; }
    }
}
