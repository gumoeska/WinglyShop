using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Order.DeleteOrder;
using WinglyShop.Application.Order.GetOrder;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class OrderController : ApiController
{
    public OrderController(IDbConnection dbConnection)
		: base(dbConnection)
	{
    }

	[HttpGet("GetOrder")]
	public async Task<IActionResult> GetOrderById([FromBody] GetOrderRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		//var command = new GetOrderCommand();

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpDelete("DeleteOrder")]
	public async Task<IActionResult> DeleteOrderById([FromBody] DeleteOrderRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		//var command = new GetOrderCommand();

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}
}