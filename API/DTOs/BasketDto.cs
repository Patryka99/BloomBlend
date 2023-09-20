namespace API.DTOs;

public class BasketDto
{
    public int Id { get; set; }
    public string ClientId { get; set; }
    public List<BasketItemDto> Items { get; set; }
    public string PaymentIntentId { get; set; }
    public string ClientSecret { get; set; }
}
