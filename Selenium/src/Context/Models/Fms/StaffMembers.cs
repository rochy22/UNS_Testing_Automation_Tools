using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(StaffMembers), Schema = Schemas.Fms)]
    public partial class StaffMembers
    {
        public StaffMembers() { }

        [Key]
        public long StaffMemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobilePhone { get; set; }

        public string OtherPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public long StaffTitleId { get; set; }
    }
}