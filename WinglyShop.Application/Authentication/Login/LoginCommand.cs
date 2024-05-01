using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.DTOs;
using WinglyShop.Domain.Entities.User;

namespace WinglyShop.Application.Authentication.Login;

public sealed record LoginCommand(string logIn, string password) : ICommand<LoginUserResultDTO>;
