using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(EnterprisesAuthentication), Schema = Schemas.Auth)]
    public partial class EnterprisesAuthentication
    {
        [Key]
        public byte EnterpriseAuthenticationId { get; set; }

        public string Name { get; set; }

        public bool PasswordHashMigrated { get; set; }

        public string Scope { get; set; }
    }
}
