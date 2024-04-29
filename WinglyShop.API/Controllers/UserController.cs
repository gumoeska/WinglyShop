using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Cart;
using WinglyShop.Application.Order.DeleteOrder;
using WinglyShop.Application.Order.GetOrder;
using WinglyShop.Application.User.Delete;
using WinglyShop.Application.User.Get;
using WinglyShop.Application.User.Update;
using WinglyShop.Application.Wishlist;
using WinglyShop.Domain.Entities.User;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class UserController : ApiController
{
    public UserController(IDbConnection dbConnection)
		: base(dbConnection)
	{
    }

	[HttpGet("GetUser")]
	public async Task<IActionResult> GetUserById([FromBody] GetUserByIdRequest request, CancellationToken cancellationToken)
	{
		// Validation
		if (request is null)
			return null;

		//var command = new UpdateUserCommand(request.user);

		// Test

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpPut("Edit")]
	public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
	{
		// Validation
		if (request is null)
			return null;

		var command = new UpdateUserCommand(request.user);

		// Test

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpPut("Delete")]
	public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request, CancellationToken cancellationToken)
	{
		// Validation
		if (request is null)
			return null;

		//var command = new UpdateUserCommand(request.user);

		// Test

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpPost("AddProductCart")]
	public async Task<IActionResult> AddProductCart([FromBody] AddProductCartRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		var command = new AddProductCartCommand(
			request.cartId,
			request.productId,
			request.quantity);

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpPost("AddProductWishlist")]
	public async Task<IActionResult> AddProductWishlist([FromBody] AddProductWishlistRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		var command = new AddProductWishlistCommand(
			request.userId,
			request.productId);

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}
}

