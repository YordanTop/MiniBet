using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MiniBet.Extension
{
    public class Authentication
    {
        [DisplayName("Card code: ")]
        [Required(ErrorMessage = "This field must be filled")]
        public string Card_Code { get; set; }

        [DisplayName("Security code: ")]
        [Required(ErrorMessage = "This field must be filled")]
        public string Security_Code { get; set; }

        public static string TypeOfPurchase { get; set; }
    }

}
