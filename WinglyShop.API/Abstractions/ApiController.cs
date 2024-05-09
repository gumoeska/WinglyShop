using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
	protected readonly IHttpContextAccessor _contextAccessor;

	protected User _userDataContext { get; set; } = new();

	protected ApiController(IDatabaseContext databaseContext, IDbConnection dbConnection, IDispatcher dispatcher, IHttpContextAccessor contextAccessor)
	{
		_databaseContext = databaseContext;
		_dbConnection = dbConnection;
		_dispatcher = dispatcher;
		_contextAccessor = contextAccessor;

		if (contextAccessor is not null)
		{
			SetUserDataContext(contextAccessor?.HttpContext?.User);
		}
	}

	protected void SetUserDataContext(ClaimsPrincipal user)
	{
		if (user.Identity.IsAuthenticated)
		{
			_userDataContext = new User();

			_userDataContext.Login = user.Claims.SingleOrDefault(x => x.Type == "Type = \"http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata\"").Value.ToString();
			_userDataContext.Name = user.Claims.SingleOrDefault(x => x.Type == nameof(ClaimTypes.Name)).Value.ToString();
			_userDataContext.Surname = user.Claims.SingleOrDefault(x => x.Type == nameof(ClaimTypes.Surname)).Value.ToString();
			//_userDataContext.Role = user.Claims.SingleOrDefault(x => x.Type == nameof(ClaimTypes.Role)).Value.ToString();


			//contextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == nameof(VariaveisUsuario.Dados.UserName)).Value
		}
	}
}
