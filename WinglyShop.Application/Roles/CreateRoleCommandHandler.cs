using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Application.Roles;

internal sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, bool>
{
	private readonly IDbConnection _dbConnection;

    public CreateRoleCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Result<bool>> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
	{
        // Validation
        if (command is null)
            return Result.Failure<bool>(Error.NullValue);

        return Result.Failure<bool>(Error.NullValue);
	}
}
