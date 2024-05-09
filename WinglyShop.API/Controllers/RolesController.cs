using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Roles;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Authorize(Roles = nameof(RoleAccess.Admin))]
[Route("api/[controller]")]
public class RolesController : ApiController
{
    public RolesController(IDatabaseContext databaseContext, IDbConnection dbConnection, IDispatcher dispatcher)
        : base(databaseContext, dbConnection, dispatcher)
    {
    }

    [HttpPost("New")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request, CancellationToken cancellationToken)
    {
        // Creating the command
        var command = new CreateRoleCommand(request.role);

		// Sending the request to the handler
		var userRequest = await _dispatcher.Send<CreateRoleCommand, bool>(command, cancellationToken);

		// Get the result
		var userResponse = userRequest.Value;

		// Validate the response
		if (userResponse is false)
		{
			return BadRequest(userResponse);
		}

		// Send response
		return Ok(Result.Success<bool>(userResponse));
	}
}