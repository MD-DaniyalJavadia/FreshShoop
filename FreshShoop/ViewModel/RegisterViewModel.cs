namespace FreshShoop.ViewModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {

    [DisplayName("Name")]
    [Required]
    public string Name { get; set; }
    [DisplayName("Email")]

    [Required]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Required]
    [Compare("Password",ErrorMessage="Passsword & Confirm Password Not Match")]
    public string ConfirmPassword { get; set; }

}

