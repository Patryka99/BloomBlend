using API.Data;
using API.DTOs;
using API.Entities;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<User> _userManager;
    private readonly TokenService _tokenService;
    private readonly StoreContext _context;
    private readonly IMapper _mapper;
    public AccountController(UserManager<User> userManager, TokenService tokenService, StoreContext context, IMapper mapper)
    {
        _context = context;
        _tokenService = tokenService;
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            return Unauthorized();
        
        var userBasket = await RetrieveBasket(loginDto.Username);
        var anonBasket = await RetrieveBasket(Request.Cookies["clientId"]);
        
        if (anonBasket != null)
        {
            if (userBasket != null) _context.Basket.Remove(userBasket);
            anonBasket.ClientId = user.UserName;
            Response.Cookies.Delete("clientId");
            await _context.SaveChangesAsync();
        }

        return new UserDto
        {
            Email = user.Email,
            Token = await _tokenService.GenerateToken(user),
            Basket = anonBasket != null ? _mapper.Map<BasketDto>(anonBasket) : _mapper.Map<BasketDto>(userBasket)
        };
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var user = new User {UserName = registerDto.Username, Email = registerDto.Email};

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        await _userManager.AddToRoleAsync(user, "Member");

        return StatusCode(201);
    }

    [Authorize]
    [HttpGet("currentUser")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        var userBasket = await RetrieveBasket(User.Identity.Name);

        return new UserDto
        {
            Email = user.Email,
            Token = await _tokenService.GenerateToken(user),
            Basket = _mapper.Map<BasketDto>(userBasket)
        };
    }

    [Authorize]
    [HttpGet("savedAddress")]
    public async Task<ActionResult<UserAddress>> GetSavedAddress()
    {
        return await _userManager.Users
                .Where(x => x.UserName == User.Identity.Name)
                .Select(user => user.Address)
                .FirstOrDefaultAsync();
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
}
