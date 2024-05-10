using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Products;
using WinglyShop.API.Attributes;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class ProductsController : ApiController
{
	public ProductsController(
		IDatabaseContext databaseContext,
		IDbConnection dbConnection,
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
	}

	[AuthAccessLevel(RoleAccess.GeneralManager)]
	[HttpPost("Create")]
	public async Task<IActionResult> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
	{
		var command = new CreateProductCommand(request.Product);

		var userRequest = await _dispatcher.Send<CreateProductCommand, bool>(command, cancellationToken);

		if (userRequest is { IsFailure: true })
		{
			return BadRequest(userRequest.Error);
		}

		return Ok(Result.Success(userRequest.Value));
	}
}
