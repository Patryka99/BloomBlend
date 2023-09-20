using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("InventoryItems")]
public class InventoryItem
{
    public int Id { get; set; }
    public int SizeMl { get; set; }
    public int PricePercent { get; set; }
    public int QuantityInStock { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
