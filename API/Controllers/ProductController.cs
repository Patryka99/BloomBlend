using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
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
    public async Task<ActionResult<List<ProductDto>>> GetProducts([FromQuery]ProductParams productParams)
    {
        var query = _context.Products
            .Include(s => s.InventoryItems)
            .Sort(productParams.OrderBy)
            .Search(productParams.SearchTerm)
            .Filter(productParams.Brands, productParams.Sexs)
            .AsQueryable();

        var products = await PagedList<Product>.ToPagedList(query, 
            productParams.PageNumber, productParams.PageSize);

        Response.AddPaginationHeader(products.MetaData);

        return _mapper.Map<List<ProductDto>>(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute]int id)
    {
        var product = await _context.Products
            .Include(s => s.InventoryItems)
            .FirstOrDefaultAsync(p => p.Id == id);

        if(product == null) return NotFound();

        return _mapper.Map<ProductDto>(product);
    }

    [HttpGet("filters")]
    public async Task<IActionResult> GetFilters()
    {
        var brands = await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();
        var sexs = await _context.Products.Select(p => p.Sex).Distinct().ToListAsync();

        return Ok(new {brands, sexs});
    }
}
