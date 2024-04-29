using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.User.Create;
using WinglyShop.Application.User.Update;
using WinglyShop.Domain.Entities.User;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class AccountController : ApiController
{
	public AccountController(IDbConnection dbConnection) 
		: base(dbConnection)
	{
	}

	[HttpPost("Create")]
	public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
	{
		// Validation
		if (request is null)
			return null;

		var user = new User(
			request.accountId, 
			request.name, 
			request.surname, 
			request.image);

		var command = new CreateUserCommand(user);

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpPut("Update")]
	public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
	{
		// Validation
		if (request is null)
			return null;

		var user = new User(
			request.accountId,
			request.name,
			request.surname,
			request.image);

		var command = new UpdateUserCommand(user);

		// Test

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}
}
