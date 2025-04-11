using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required] public string Name { get; set; } = string.Empty;

    [EmailAddress] public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    // Navigation Property
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}