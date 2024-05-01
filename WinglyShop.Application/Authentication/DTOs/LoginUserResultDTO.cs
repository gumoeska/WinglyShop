using WinglyShop.Domain.Entities.Role;
using WinglyShop.Domain.Entities.User;

namespace WinglyShop.Application.Authentication.DTOs;

public sealed record LoginUserResultDTO(User user, Role role);
