using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.User;
using WinglyShop.Shared;

namespace WinglyShop.Application.Users.Get;

internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
{
    private readonly IDbConnection _dbConnection;

    public GetUserByIdQueryHandler(IDbConnection dbConnection) 
		=> (_dbConnection) = (dbConnection);

    public async Task<Result<User>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
	{
		var user = new User(5, "Gustavo", "Moeska", "img");

		//return Result.Failure<User>(Error.NullValue);
		return Result.Success<User>(user);
	}
}
