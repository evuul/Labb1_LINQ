using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.models;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }

    [Required]
    public decimal TotalAmount { get; set; }

    public string? Status { get; set; }

    public Customer Customer { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}