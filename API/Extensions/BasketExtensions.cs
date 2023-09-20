using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class BasketExtensions
{
    public static IQueryable<Basket> RetrieveBasketWithItems(this IQueryable<Basket> query, string ClientId)
    {
        return query.Include(i => i.Items)
                .ThenInclude(p => p.Product).Where(b => b.ClientId == ClientId);
    }
}