using Microsoft.AspNetCore.Mvc;
using WinglyShop.Application.Abstractions.Data;

namespace WinglyShop.API.Abstractions;

[ApiController]
public class ApiController : ControllerBase
{
	protected readonly IDbConnection _dbConnection;

	protected ApiController(IDbConnection dbConnection)
	{
		_dbConnection = dbConnection;
	}
}
