using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

// används för att visa + uppdatera user-data
public class MyAccountViewModel
{
    public string Id { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }
}