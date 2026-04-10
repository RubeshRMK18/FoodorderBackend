using FoodorderBackend.Data;
using FoodorderBackend.DTO;
using FoodorderBackend.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    // ✅ REGISTER
    public string Register(RegisterDto dto)
    {
        var userExists = _context.Users.Any(u => u.Email == dto.Email);

        if (userExists)
            return "User already exists";

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return "Registered successfully";
    }

    // ✅ LOGIN + TOKEN
    public object Login(LoginDto dto)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);

        if (user == null)
            return null;

        var token = GenerateJwtToken(user);

        return new
        {
            token = token,
            userId = user.Id,
            name = user.Name
        };
    }

    // 🔐 TOKEN GENERATION
    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("super_secret_key_12345"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}