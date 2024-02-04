using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBet.DataModels
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PurchaseId { get;set; }
        public string Card_Code { get; set; }
        public string Security_Code { get; set; }
       
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
        
        [ForeignKey("PurchaseId")]
        public virtual Purchases Purchases { get; set; }
    }
}
