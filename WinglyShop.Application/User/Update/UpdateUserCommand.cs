using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.User.Update;

public sealed record UpdateUserCommand(Domain.Entities.User.User user) : ICommand<bool>;
