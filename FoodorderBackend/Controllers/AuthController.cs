 using FoodorderBackend.DTO;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    // ✅ REGISTER
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto dto)
    {
        var result = _authService.Register(dto);

        if (result.Contains("exists"))
            return BadRequest(result);

        return Ok(result);
    }

    // ✅ LOGIN WITH TOKEN
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        var result = _authService.Login(dto);

        if (result == null)
            return Unauthorized("Invalid email or password");

        return Ok(result);
    }
}