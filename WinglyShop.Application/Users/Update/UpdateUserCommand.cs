using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.User;

namespace WinglyShop.Application.Users.Update;

public sealed record UpdateUserCommand(User user) : ICommand<bool>;
