using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Application.Authentication.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, bool>
{
	private readonly IDatabaseContext _context;
    private readonly IDbConnection _dbConnection;

    public RegisterCommandHandler(IDatabaseContext context, IDbConnection dbConnection)
    {
		_context = context;
        _dbConnection = dbConnection;
    }

	// Temporary EF Implementation
	public async Task<Result<bool>> Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		// Validate
		if (command is null)
			throw new ArgumentNullException(nameof(command));

		// Inserting data
		try
		{
			// Checking if the user already exists
			var userExists = await _context.Users
				.AnyAsync(x => x.Login == command.User.Login);

			// Validate if user already exists
			if (userExists is true)
				return Result.Failure<bool>(new Error("Error", "User already exists."));

			// Insert data into database
			await _context.Users.AddAsync(command.User);
		}
		catch (Exception ex)
		{
			return Result.Failure<bool>(new Error("Error", "An error occoured."));
		}

		return Result.Success(true);
	}

    public async Task<Result<bool>> HandleOld(RegisterCommand command, CancellationToken cancellationToken)
	{
		// Validate
		if (command is null)
			throw new ArgumentNullException(nameof(command));

		// Database Connection
		await using var dbConnection = _dbConnection.CreateConnection();

		// Queries
		var registerQuery = RegisterDbQueries.RegisterQuery();

		// Transaction
		using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
		{
			try
			{
				// Open Connection
				await dbConnection.OpenAsync(cancellationToken);

				// Insert command returning the affectedRow
				var affectedRow = await dbConnection
					.ExecuteAsync(registerQuery, command.User);

				transaction.Complete();

				if (affectedRow is > 0)
				{
					return Result.Success<bool>(true);
				}
			}
			catch (Exception)
			{
				transaction.Dispose();

				return Result.Failure<bool>(Error.NullValue);
			}

			return Result.Failure<bool>(Error.NullValue);
		}
	}
}