using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBet.DataModels
{
    public class Invitations
    {
        [Key]
        public int InvitationId { get; set; }
        public int UserId { get; set; }
        public string? Friends { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
}
