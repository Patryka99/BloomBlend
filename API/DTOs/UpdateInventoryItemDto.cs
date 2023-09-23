using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UpdateInventoryItemDto
{
    public int Id { get; set; }
    [Required]
    [Range(100, Double.PositiveInfinity)]
    public int SizeMl { get; set; }

    [Required]
    [Range(20, Double.PositiveInfinity)]
    public int PricePercent { get; set; }

    [Required]
    [Range(0, Double.PositiveInfinity)]
    public int QuantityInStock { get; set; }
}
