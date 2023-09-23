using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductController : BaseApiController
{
    private readonly StoreContext _context;
    private readonly IMapper _mapper;
    private readonly ImageService _imageService;
    public ProductController(StoreContext context, IMapper mapper, ImageService imageService)
    {
        _imageService = imageService;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts([FromQuery] ProductParams productParams)
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

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int id)
    {
        var product = await _context.Products
            .Include(s => s.InventoryItems)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return NotFound();

        return _mapper.Map<ProductDto>(product);
    }

    [HttpGet("filters")]
    public async Task<IActionResult> GetFilters()
    {
        var brands = await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();
        var sexs = await _context.Products.Select(p => p.Sex).Distinct().ToListAsync();

        return Ok(new { brands, sexs });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<CreateProductDto>> CreateProduct([FromForm]CreateProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Sex = productDto.Sex,
            Brand = productDto.Brand,
            Price = productDto.Price,
            InventoryItems = productDto.InventoryItems.Select(item => new InventoryItem
            {
                SizeMl = item.SizeMl,
                PricePercent = item.PricePercent,
                QuantityInStock = item.QuantityInStock
            }).ToList()
        };

        if (productDto.PictureUrl != null)
        {
            var imageResult = await _imageService.AddImageAsync(productDto.PictureUrl);

            if(imageResult.Error != null) 
                return BadRequest(new ProblemDetails{Title = imageResult.Error.Message});

            product.PictureUrl = imageResult.SecureUrl.ToString();
            product.PublicId = imageResult.PublicId;
            if (productDto.PictureUrl2 != null)
            {
                var imageResult2 = await _imageService.AddImageAsync(productDto.PictureUrl2);

                if(imageResult2.Error != null) 
                    return BadRequest(new ProblemDetails{Title = imageResult2.Error.Message});

                product.PictureUrl2 = imageResult2.SecureUrl.ToString();
                product.PublicId2 = imageResult2.PublicId;
            }
            if (productDto.PictureUrl3 != null)
            {
                var imageResult3 = await _imageService.AddImageAsync(productDto.PictureUrl3);

                if(imageResult3.Error != null) 
                    return BadRequest(new ProblemDetails{Title = imageResult3.Error.Message});

                product.PictureUrl3 = imageResult3.SecureUrl.ToString();
                product.PublicId3 = imageResult3.PublicId;
            }
        }

        _context.Products.Add(product);

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return CreatedAtRoute("GetProduct", new { Id = product.Id }, productDto);

        return BadRequest(new ProblemDetails { Title = "Problem creating new product" });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<ActionResult> UpdateProduct([FromForm]UpdateProductDto productDto)
    {
        var product = await _context.Products.FindAsync(productDto.Id);

        if (product == null) return NotFound();

        foreach (var item in product.InventoryItems)
        {
            _mapper.Map(productDto.InventoryItems, item);
        }

        _mapper.Map(productDto, product);

        if (productDto.PictureUrl != null)
        {
            var imageResult = await _imageService.AddImageAsync(productDto.PictureUrl);

            if(imageResult.Error != null) 
                return BadRequest(new ProblemDetails{Title = imageResult.Error.Message});

            if (!string.IsNullOrEmpty(product.PublicId)) 
                await _imageService.DeleteImageAsync(product.PublicId);

            product.PictureUrl = imageResult.SecureUrl.ToString();
            product.PublicId = imageResult.PublicId;
        }

        if (productDto.PictureUrl2 != null)
        {
            var imageResult = await _imageService.AddImageAsync(productDto.PictureUrl2);

            if(imageResult.Error != null) 
                return BadRequest(new ProblemDetails{Title = imageResult.Error.Message});

            if (!string.IsNullOrEmpty(product.PublicId2)) 
                await _imageService.DeleteImageAsync(product.PublicId2);

            product.PictureUrl2 = imageResult.SecureUrl.ToString();
            product.PublicId2 = imageResult.PublicId;
        }

        if (productDto.PictureUrl3 != null)
        {
            var imageResult = await _imageService.AddImageAsync(productDto.PictureUrl3);

            if(imageResult.Error != null) 
                return BadRequest(new ProblemDetails{Title = imageResult.Error.Message});

            if (!string.IsNullOrEmpty(product.PublicId3)) 
                await _imageService.DeleteImageAsync(product.PublicId3);

            product.PictureUrl3 = imageResult.SecureUrl.ToString();
            product.PublicId3 = imageResult.PublicId;
        }

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return NoContent();

        return BadRequest(new ProblemDetails { Title = "Problem updating product" });
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null) return NotFound();

        if (!string.IsNullOrEmpty(product.PublicId3)) 
                await _imageService.DeleteImageAsync(product.PublicId3);

        _context.Products.Remove(product);

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest(new ProblemDetails { Title = "Problem Deleting product" });
    }
}
