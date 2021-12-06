using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Specialties), Schema = Schemas.Auth)]
    public partial class Specialties
    {
        [Key]
        public int SpecialtyId { get; set; }

        public string Name { get; set; }

        public bool RobotPipEnabled { get; set; }
    }
}
