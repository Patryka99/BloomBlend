using System.Reflection.Metadata.Ecma335;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class BasketController : BaseApiController
{
    private readonly StoreContext _context;
    private readonly IMapper _mapper;
    public BasketController(StoreContext context, IMapper mapper)
    {
        this._mapper = mapper;
        this._context = context;
    }

    [HttpGet(Name = "GetBasket")]
    public async Task<ActionResult<BasketDto>> GetBasket()
    {
        var basket = await RetrieveBasket(GetClientId());

        if (basket == null) return NotFound();
        return _mapper.Map<BasketDto>(basket);
    }

    [HttpPost]
    public async Task<ActionResult<BasketDto>> AddItemToBasket(int productId, int quantity, int sizeMl)
    {
        var basket = await RetrieveBasket(GetClientId());

        basket ??= CreateBasket();

        var product = await _context.Products.FindAsync(productId);

        if (product == null) return BadRequest(new ProblemDetails{Title = "Product not found"});

        var inventoryItem = await _context.InventoryItems.FirstOrDefaultAsync(x => x.ProductId == productId && x.SizeMl == sizeMl);

        basket.AddItem(product, quantity, sizeMl, inventoryItem.PricePercent);

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return CreatedAtRoute("GetBasket", _mapper.Map<BasketDto>(basket));
        return BadRequest( new ProblemDetails{Title = "Problem saving item to basket"});
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBasketItem(int productId, int quantity, int sizeMl)
    {
        var basket = await RetrieveBasket(GetClientId());

        if (basket == null) return NotFound();

        basket.RemoveItem(productId, quantity, sizeMl);

        var result = await _context.SaveChangesAsync() > 0;
        if(result) return Ok();
        return BadRequest(new ProblemDetails{Title = "Problem removing item from the basket"});
    }

    private async Task<Basket> RetrieveBasket(string clientId)
    {
        if (string.IsNullOrEmpty(clientId))
        {
            Response.Cookies.Delete("clientId");
            return null;
        }

        return await _context.Basket
            .Include(i => i.Items)
                .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(b => b.ClientId == clientId);
    }

    private string GetClientId()
    {
        return User.Identity?.Name ?? Request.Cookies["clientId"];
    }

    private Basket CreateBasket()
    {
        var clientId = User.Identity.Name;
        if (string.IsNullOrEmpty(clientId))
        {
            clientId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("clientId", clientId, cookieOptions);
        }

        var basket = new Basket { ClientId = clientId };
        _context.Basket.Add(basket);
        return basket;
    }
}
