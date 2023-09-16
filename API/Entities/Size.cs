namespace API.Entities;

public class Size
{
    public int Id { get; set; }
    public int SizeMl { get; set; }
    public List<Product> Products { get; set; } = new ();
}
