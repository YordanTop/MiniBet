using System.ComponentModel.DataAnnotations;

namespace MiniBet.DataModels
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string EmailAddress { get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Coins { get; set; }
    }
}
