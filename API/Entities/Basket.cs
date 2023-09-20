namespace API.Entities;

public class Basket
{
    public int Id { get; set; }
    public string ClientId { get; set; }
    public List<BasketItem> Items { get; set; } = new();
    public string PaymentIntentId { get; set; }
    public string ClientSecret { get; set; }

    public void AddItem(Product product, int quantity, int sizeMl, int pricePercent)
    {
        if (Items.All(item => item.ProductId != product.Id || item.SizeMl != sizeMl))
        {
            Items.Add(new BasketItem { Product = product, Quantity = quantity ,SizeMl = sizeMl, PricePercent = pricePercent });
        }

        var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
        if (existingItem != null) existingItem.Quantity += quantity;
    }

    public void RemoveItem(int productId, int quantity, int sizeMl)
    {
        var item = Items.FirstOrDefault(item => item.ProductId == productId && item.SizeMl == sizeMl);

        if (item == null) return;

        item.Quantity -= quantity;

        if (item.Quantity == 0) Items.Remove(item);
    }
}
