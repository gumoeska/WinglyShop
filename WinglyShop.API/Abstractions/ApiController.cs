using Microsoft.AspNetCore.Mvc;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;

namespace WinglyShop.API.Abstractions;

[ApiController]
public class ApiController : ControllerBase
{
	protected readonly IDatabaseContext _databaseContext;
	protected readonly IDbConnection _dbConnection;
	protected readonly IDispatcher _dispatcher;

	protected ApiController(IDatabaseContext databaseContext, IDbConnection dbConnection, IDispatcher dispatcher)
	{
		_databaseContext = databaseContext;
		_dbConnection = dbConnection;
		_dispatcher = dispatcher;
	}
}
