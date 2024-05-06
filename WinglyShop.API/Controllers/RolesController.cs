using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Roles;

namespace WinglyShop.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class RolesController : ApiController
{
    public RolesController(IDatabaseContext databaseContext, IDbConnection dbConnection, IDispatcher dispatcher)
        : base(databaseContext, dbConnection, dispatcher)
    {
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request, CancellationToken cancellationToken)
    {
        // Creating the command
        var command = new CreateRoleCommand(request.role);

        return Ok();
    }

}