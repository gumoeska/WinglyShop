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

	public Task<Result<User>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
