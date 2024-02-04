using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBet.DataModels
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserRoles{ get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
}
