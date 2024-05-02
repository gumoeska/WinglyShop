using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Role;

namespace WinglyShop.Application.Roles;

public sealed record CreateRoleCommand(Role role) : ICommand<bool>;
