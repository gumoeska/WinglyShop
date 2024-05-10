using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Authentication.DTOs;
using WinglyShop.Application.Authentication.Login;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Application.Products;

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

	public async Task<IActionResult> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
	{
		// Creating the command
	}
}