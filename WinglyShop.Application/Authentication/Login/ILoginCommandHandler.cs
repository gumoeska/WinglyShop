using WinglyShop.Domain.Entities.User;
using WinglyShop.Shared;

namespace WinglyShop.Application.Authentication.Login
{
	internal interface ILoginCommandHandler
	{
		Task<Result<User>> Handle(LoginCommand command, CancellationToken cancellationToken);
	}
}