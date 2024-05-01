using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.User;

namespace WinglyShop.Application.Users.Get;

public sealed record GetUserByIdQuery(int userId) : IQuery<User>;
