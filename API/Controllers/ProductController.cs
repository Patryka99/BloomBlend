using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductController : BaseApiController
{
    private readonly StoreContext _context;
    private readonly IMapper _mapper;
    public ProductController(StoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        var products = await _context.ProductsSizes
            .Include(p => p.Product)
            .ThenInclude(s => s.Sizes)
            .ToListAsync();

        var productsDto = _mapper.Map<List<ProductDto>>(products);

        return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute]int id)
    {
        var product = await _context.ProductsSizes
            .Include(p => p.Product)
            .ThenInclude(s => s.Sizes)
            .FirstOrDefaultAsync(p => p.Product.Id == id);

        return _mapper.Map<ProductDto>(product);
    }
}
