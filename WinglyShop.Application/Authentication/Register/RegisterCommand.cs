using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.User;

namespace WinglyShop.Application.Authentication.Register;

public sealed record RegisterCommand(User user) : ICommand<bool>;
