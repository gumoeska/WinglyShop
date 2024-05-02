using Dapper;
using System.Transactions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;
using WinglyShop.Shared.Extensions;

namespace WinglyShop.Application.Authentication.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, bool>
{
    private readonly IDbConnection _dbConnection;

    public RegisterCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Result<bool>> Handle(RegisterCommand command, CancellationToken cancellationToken)
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
					.ExecuteAsync(registerQuery, command.user);

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