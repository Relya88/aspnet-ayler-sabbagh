using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

// för att ta emot logindata från formuläret
public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}