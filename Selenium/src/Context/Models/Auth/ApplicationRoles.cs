using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ApplicationRoles), Schema = Schemas.Auth)]
    public class ApplicationRoles
    {
        [Key]
        public int RoleId { get; set; }

        public int ApplicationId { get; set; }

        public string Name { get; set; }
    }
}

