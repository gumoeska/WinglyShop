using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Domain.Common.DTOs.Users;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.API.Abstractions;

[ApiController]
public class ApiController : ControllerBase
{
	protected readonly IDispatcher _dispatcher;
	protected readonly IDbConnection _dbConnection;
	protected readonly IDatabaseContext _databaseContext;
	protected readonly IUserAccessor _userAccessor;

	protected ApiController(
		IDatabaseContext databaseContext, 
		IDbConnection dbConnection, 
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
	{
		_databaseContext = databaseContext;
		_dbConnection = dbConnection;
		_dispatcher = dispatcher;
		_userAccessor = userAccessor;
	}
}
