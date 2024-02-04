using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBet.DataModels
{
    public class Stats
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? Wins { get; set; }
        public int? Loses { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

    }
}
