using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Application.Authentication.DTOs;

namespace WinglyShop.API.Services.Auth;

public class TokenService : ITokenService
{
	private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(LoginUserResultDTO userData)
	{
		List<Claim> claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, userData.User.Login),
			new Claim(ClaimTypes.Role, userData.Role.Access.GetDisplayName())
		};

		var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey.Key));

		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

		var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddDays(1),
			signingCredentials: credentials);

		var jwt = new JwtSecurityTokenHandler().WriteToken(token);

		return jwt;
	}
}
