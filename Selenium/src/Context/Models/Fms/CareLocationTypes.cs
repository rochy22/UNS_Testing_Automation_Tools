using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(CareLocationTypes), Schema = Schemas.Fms)]
    public partial class CareLocationTypes
    {
        public CareLocationTypes() { }

        [Key]
        public long CareLocationTypeId { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }
    }
}
