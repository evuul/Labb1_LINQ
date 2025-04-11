using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.models;

public class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? ContactPerson { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public string? Phone { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}