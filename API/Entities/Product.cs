namespace API.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public string PictureUrl2 { get; set; }
    public string PictureUrl3 { get; set; }
    public string Sex { get; set; }
    public string Brand { get; set; }
    public List<Size> Sizes { get; set; } = new ();
}
