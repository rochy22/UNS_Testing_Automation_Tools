using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Countries), Schema = Schemas.Fms)]
    public partial class Countries
    {
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }
    }
}