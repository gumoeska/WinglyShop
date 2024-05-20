using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Products;
using WinglyShop.API.Attributes;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Shared;
using WinglyShop.Application.Carts;
using WinglyShop.Application.Wishlist;
using Microsoft.AspNetCore.Authorization;
using WinglyShop.Application.Products.Get;
using WinglyShop.Domain.Entities.Products;

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

	[AllowAnonymous]
	[HttpGet]
	public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
	{
		var query = new GetProductListQuery();

		var userRequest = await _dispatcher.Query<GetProductListQuery, List<Product>>(query, cancellationToken);

		if (userRequest is { IsFailure: true })
		{
			return BadRequest(userRequest.Error);
		}

		return Ok(Result.Success(userRequest.Value));
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

	[HttpPost("cart/{productId}/add")]
	public async Task<IActionResult> UserAddProductToCart([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
	{
		// receber o id do produto e o usuário da requisição
		return Ok();
	}

	[HttpDelete("cart/{productId}/remove")]
	public async Task<IActionResult> UserRemoveProductFromCart(CreateProductRequest request, CancellationToken cancellationToken)
	{
		return Ok();
	}

    [HttpPost("wishlist/{productId}/add")]
    public async Task<IActionResult> UserAddProductToWishlist([FromBody] AddProductWishlistRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpDelete("wishlist/{productId}/remove")]
    public async Task<IActionResult> UserRemoveProductFromWishlist([FromBody] AddProductWishlistRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }
}
