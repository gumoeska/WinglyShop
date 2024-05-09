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
		//var claims = new List<Claim>()
		//	{
		//		new(nameof(UsuarioLoginDto.UserName), userAut.UserName),
		//		new(nameof(Variaveis.Valores.IdEntidade), userAut.IdEntidadeGr3bDataBase.ToString()),
		//		new(ClaimTypes.Name, UtilsDominio.RemoverAcentos(userAut.DescUsuario)),
		//		new(ClaimTypes.Sid, userAut.CodUsuario.ToString()),
		//		new(nameof(SignalRName.Group), userAut.DescEntidade.ToUpper()),
		//		new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		//	};

		List<Claim> claims = new List<Claim>
		{
			new Claim(ClaimTypes.UserData, userData.User.Login),
			new Claim(ClaimTypes.Name, userData.User.Name),
			new Claim(ClaimTypes.Surname, userData.User.Surname),
			new Claim(ClaimTypes.Role, userData.Role.Access.GetDisplayName()),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

		var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey.Key));

		var keyTest = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey:Token"]));

		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

		var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddDays(1),
			signingCredentials: credentials);

		var jwt = new JwtSecurityTokenHandler().WriteToken(token);

		return jwt;
	}
}
