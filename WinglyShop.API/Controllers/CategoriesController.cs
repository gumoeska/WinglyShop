using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Attributes;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Categories;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Shared;

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

	[AuthAccessLevel(RoleAccess.GeneralManager)]
	[HttpPost("Create")]
	public async Task<IActionResult> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
	{
		var command = new CreateCategoryCommand(request.Category);

		var userRequest = await _dispatcher.Send<CreateCategoryCommand, bool>(command, cancellationToken);

		if (userRequest is { IsFailure: true })
		{
			return BadRequest(userRequest.Error);
		}

		return Ok(Result.Success(userRequest.Value));
	}
}
