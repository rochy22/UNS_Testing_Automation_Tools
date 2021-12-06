using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ProductKeys), Schema = Schemas.Prod)]
    public partial class ProductKeys
    {
        [Key]
        public long ProductKeyId { get; set; }

        public string ProductKey { get; set; }

        public long AllocatedForProductId { get; set; }

        public int IsDelivered { get; set; }

        public bool IsValidated { get; set; }

        public Products AllocatedForProduct { get; set; }
    }
}
