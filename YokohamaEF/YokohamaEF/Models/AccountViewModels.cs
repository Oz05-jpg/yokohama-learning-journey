using System.ComponentModel.DataAnnotations;

namespace YokohamaEF.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password ไม่ตรงกัน")]
    public required string ConfirmPassword { get; set; }

}


public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }


    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public bool RememberMe { get; set; }
}



