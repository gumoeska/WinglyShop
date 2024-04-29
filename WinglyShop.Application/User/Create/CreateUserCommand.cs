using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.User;

namespace WinglyShop.Application.User.Create;

public sealed record CreateUserCommand(Domain.Entities.User.User user) : ICommand<bool>;
