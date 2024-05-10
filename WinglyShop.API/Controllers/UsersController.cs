using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Attributes;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Carts;
using WinglyShop.Application.Users.Delete;
using WinglyShop.Application.Users.Get;
using WinglyShop.Application.Users.GetById;
using WinglyShop.Application.Users.SetAccess;
using WinglyShop.Application.Users.Update;
using WinglyShop.Application.Wishlist;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class UsersController : ApiController
{
	public UsersController(
		IDatabaseContext databaseContext,
		IDbConnection dbConnection,
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
	}

	[HttpGet]
	//[Authorize(Roles = nameof(RoleAccess.Admin))]
	[AuthAccessLevel(RoleAccess.Manager)]
	public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
	{
		// Creating the query
		var query = new GetUsersQuery();

		// Sending the request to the handler
		var userRequest = await _dispatcher.Query<GetUsersQuery, List<User>>(query, cancellationToken);

		// Validate the response
		if (userRequest is { IsFailure: true })
			return BadRequest(userRequest.Error);

		//-- TESTE --// (Remover)
		var test = _userAccessor.GetCurrentUsername();
		//-- TESTE --//

		return Ok(Result.Success(userRequest.Value));
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetUserById([FromBody] GetUserByIdRequest request, CancellationToken cancellationToken)
	{
		// Creating the query
		var query = new GetUserByIdQuery(request.userId);

		// Sending the request to the handler
		var userRequest = await _dispatcher.Query<GetUserByIdQuery, User?>(query, cancellationToken);

		// Validate the request
		if (userRequest is { IsFailure: true })
			return BadRequest(userRequest.Error);

		// Get the User
		var userResponse = userRequest.Value;

		// Validate the userResponse
		if (userResponse is null)
			return BadRequest(userResponse);

		return Ok(Result.Success<User?>(userResponse));
	}

	[HttpPut("Edit")]
	public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
	{
		return Ok();
	}

	[HttpDelete("Delete")]
	public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request, CancellationToken cancellationToken)
	{
		return Ok();
	}

	[HttpPut("AccessLevel")]
	[AuthAccessLevel(RoleAccess.Admin)]
	public async Task<IActionResult> SetUserAccess([FromBody] SetUserAccessLevelRequest request, CancellationToken cancellationToken)
	{
		// Creating the command
		var command = new SetUserAccessLevelCommand(request.UserId, request.AccessLevel);

		var userRequest = await _dispatcher.Send<SetUserAccessLevelCommand, bool>(command, cancellationToken);

		if (userRequest is { IsFailure: true })
		{
			return BadRequest(userRequest.Error);
		}

		return Ok(Result.Success(userRequest.Value));
	}

	[HttpPost("AddProductCart")]
	public async Task<IActionResult> AddProductCart([FromBody] AddProductCartRequest request, CancellationToken cancellationToken)
	{
		return Ok();
	}

	[HttpPost("AddProductWishlist")]
	public async Task<IActionResult> AddProductWishlist([FromBody] AddProductWishlistRequest request, CancellationToken cancellationToken)
	{
		return Ok();
	}
}

