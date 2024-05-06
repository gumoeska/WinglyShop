using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Roles;

namespace WinglyShop.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class RoleController : ApiController
{
    public RoleController(IDbConnection dbConnection, IDispatcher dispatcher)
        : base(dbConnection, dispatcher)
    {
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request, CancellationToken cancellationToken)
    {
        // Creating the command
        var command = new CreateRoleCommand(request.role);

        return Ok();
    }

}