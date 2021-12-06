using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(Timezones), Schema = Schemas.Fms)]
    public partial class Timezones
    {
        [Key]
        public int TimezoneId { get; set; }

        public string TimeZoneInfoId { get; set; }
    }
}