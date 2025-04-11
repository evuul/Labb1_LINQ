using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1_LINQ.models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    // Foreign Keys
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }

    // Navigation Properties
    public Category Category { get; set; } = null!;
    public Supplier Supplier { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}