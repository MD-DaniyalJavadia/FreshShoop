namespace FreshShoop.ViewModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {

    [Required]
    [DisplayName("Name")]
        public string Name { get; set; }
    [DisplayName("Email")]

    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage="Passsword & Confirm Password Not Match")]
    public string ConfirmPassword { get; set; }

}

