using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(States), Schema = Schemas.Fms)]
    public partial class States
    {
        [Key]
        public int StateId { get; set; }

        public string Acronym { get; set; }

        public string Name { get; set; }
    }
}