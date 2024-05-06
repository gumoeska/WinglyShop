using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Application.Authentication.Register;

public sealed record RegisterCommand(User User) : ICommand<bool>;
