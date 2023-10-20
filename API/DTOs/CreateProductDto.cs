using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public IFormFile PictureUrl { get; set; }

    public IFormFile PictureUrl2 { get; set; }

    public IFormFile PictureUrl3 { get; set; }

    [Required]
    public string Sex { get; set; }

    [Required]
    public string Brand { get; set; }

    [Required]
    public long Price { get; set; }

}
