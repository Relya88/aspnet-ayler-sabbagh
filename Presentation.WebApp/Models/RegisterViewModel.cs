using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}