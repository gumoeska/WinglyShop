using Microsoft.AspNetCore.Mvc;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;

namespace WinglyShop.API.Abstractions;

[ApiController]
public class ApiController : ControllerBase
{
	protected readonly IDbConnection _dbConnection;
	protected readonly IDispatcher _dispatcher;

	protected ApiController(IDbConnection dbConnection, IDispatcher dispatcher)
	{
		_dbConnection = dbConnection;
		_dispatcher = dispatcher;
	}
}
