using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(ChallengeQuestions), Schema = Schemas.Auth)]
    public partial class ChallengeQuestions
    {
        [Key]
        public int ChallengeQuestionId { get; set; }

        public string Question { get; set; }
    }
}
