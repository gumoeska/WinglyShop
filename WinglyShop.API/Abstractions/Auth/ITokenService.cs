using WinglyShop.Application.Authentication.DTOs;

namespace WinglyShop.API.Abstractions.Auth;

public interface ITokenService
{
	string GenerateToken(LoginUserResultDTO user);
}
