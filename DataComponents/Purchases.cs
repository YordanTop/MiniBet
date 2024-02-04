using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBet.DataModels
{
    public class Purchases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseID { get; set; }
        public int UserID { get; set; }
        public int? Coins { get; set; }
        public float Price { get; set; }
        public DateTime Date_Log { get; set; }

        [Required]
        public virtual Transaction Transaction { get; set; }

    }
}
