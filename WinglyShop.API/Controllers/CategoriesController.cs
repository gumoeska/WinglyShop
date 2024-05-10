using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class CategoriesController : ApiController
{
	public CategoriesController(
		IDatabaseContext databaseContext,
		IDbConnection dbConnection,
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
	}

	public async Task<IActionResult> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
	{

	}
}
