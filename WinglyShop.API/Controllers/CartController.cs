using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Cart;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class CartController : ApiController
{
    public CartController(IDbConnection dbConnection, IDispatcher dispatcher)
		: base(dbConnection, dispatcher)
	{
    }

	[HttpPost("AddProduct")]
	public async Task<IActionResult> AddProduct([FromBody] AddProductCartRequest request, CancellationToken cancellationToken)
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
}
