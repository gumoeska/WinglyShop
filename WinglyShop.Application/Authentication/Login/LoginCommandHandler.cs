using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.DTOs;
using WinglyShop.Domain.Entities.Roles;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;

namespace WinglyShop.Application.Authentication.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginUserResultDTO>
{
	private readonly IDbConnection _dbConnection;
	private readonly IDatabaseContext _context;

	public LoginCommandHandler(IDbConnection dbConnection, IDatabaseContext dbContext)
		=> (_dbConnection, _context) = (dbConnection, dbContext);

	public async Task<Result<LoginUserResultDTO>> Handle(LoginCommand command, CancellationToken cancellationToken)
	{
		// Validate
		if (command is null)
			throw new ArgumentNullException(nameof(command));

		// Try to return the user
		var user = await _context.Users
			.Where(x => x.Login == command.logIn 
					 && x.Password == command.password)
			.FirstOrDefaultAsync();

		// Validate the user
		if (user is null)
		{
			return Result.Failure<LoginUserResultDTO>(Error.NullValue);
		}

		// if the user is not null, return the role
		var role = await _context.Roles
			.Where(x => x.Id == user.IdRole)
			.FirstOrDefaultAsync();

		if (role is null)
		{
			return Result.Failure<LoginUserResultDTO>(Error.NullValue);
		}

		// Building the object
		var userData = new LoginUserResultDTO(user, role);

		return Result.Success<LoginUserResultDTO>(userData);
	}

	#region Old handler using Dapper
	public async Task<Result<LoginUserResultDTO>> HandleOld(LoginCommand command, CancellationToken cancellationToken)
	{
		// Validate
		if (command is null)
			throw new ArgumentNullException(nameof(command));

		// Database Connection
		await using var dbConnection = _dbConnection.CreateConnection();
		await dbConnection.OpenAsync(cancellationToken);

		// Queries
		var logInQuery = LoginDbQueries.LogInQuery();
		var userRoleQuery = LoginDbQueries.UserRoleQuery();

		// Try to return the user
		var user = await dbConnection.QueryFirstOrDefaultAsync<User>(
			logInQuery,
			new
			{
				Login = command.logIn,
				Password = command.password
			});

		// Validate the user
		if (user is null)
		{
			return Result.Failure<LoginUserResultDTO>(Error.NullValue);
		}

		// if the user is not null, return the role
		var role = await dbConnection.QueryFirstOrDefaultAsync<Role>(
			userRoleQuery,
			new
			{
				RoleId = user.IdRole
			});

		if (role is null)
		{
			return Result.Failure<LoginUserResultDTO>(Error.NullValue);
		}

		// Building the object
		var userData = new LoginUserResultDTO(user, role);

		return Result.Success<LoginUserResultDTO>(userData);
	}
	#endregion
}
