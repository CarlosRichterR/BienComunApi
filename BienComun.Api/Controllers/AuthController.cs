using BienComun.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BienComun.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        bool isValidUser = await _userService.LoginAsync(loginRequest);

        if (isValidUser)
        {
            return Ok(new { Message = "Login successful" });
        }
        else
        {
            return Unauthorized(new { Message = "Invalid credentials" });
        }
    }
}
