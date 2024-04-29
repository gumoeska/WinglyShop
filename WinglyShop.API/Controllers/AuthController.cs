using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Authentication.Login;
using WinglyShop.Application.Authentication.Register;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class AuthController : ApiController
{
	public AuthController(IDbConnection dbConnection)
		: base(dbConnection)
	{
	}

	[HttpPost("Login")]
	public async Task<IActionResult> LoginAccount([FromBody] LoginRequest request, CancellationToken cancellationToken)
	{
		// Test
		//if (request is null)
		//	return null;

		//var command = new LoginCommand(request.email, request.password);

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpPost("Register")]
	public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequest request, CancellationToken cancellationToken)
	{
		//if (request is null)
		//	return null;

		//var command = new RegisterCommand(request.email, request.password);

		//Result<Guid> result = await _dispatcher.Send<RegisterCommand, Guid>(command, cancellationToken);

		//if (result.IsFailure)
		//	return null;

		Result<Guid> result = Guid.NewGuid();

		return Ok(result);
	}
}
