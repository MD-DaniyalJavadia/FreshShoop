using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FreshShoop.ViewModel
{
    public class LoginViewModel
    {

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public bool RemberMe { get; set; }

    }
}
