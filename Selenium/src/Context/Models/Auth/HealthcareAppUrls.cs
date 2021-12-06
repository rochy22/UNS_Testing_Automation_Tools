using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(HealthcareAppUrls), Schema = Schemas.Auth)]
    public partial class HealthcareAppUrls
    {
        [Key]
        public long HealthcareAppUrlId { get; set; }
    }
}
