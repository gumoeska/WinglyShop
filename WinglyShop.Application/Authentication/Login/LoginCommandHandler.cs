using Dapper;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.DTOs;
using WinglyShop.Domain.Entities.Role;
using WinglyShop.Domain.Entities.User;
using WinglyShop.Shared;

namespace WinglyShop.Application.Authentication.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginUserResultDTO>
{
	private readonly IDbConnection _dbConnection;

	public LoginCommandHandler(IDbConnection dbConnection)
		=> (_dbConnection) = (dbConnection);

	public async Task<Result<LoginUserResultDTO>> Handle(LoginCommand command, CancellationToken cancellationToken)
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
}
