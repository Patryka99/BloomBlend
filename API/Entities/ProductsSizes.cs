using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class ProductsSizes
{
    public int Id { get; set; }
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public int SizeId { get; set; }
    public Size Size { get; set; }

    public long Price { get; set; }
    public int QuantityInStock { get; set; }
}
