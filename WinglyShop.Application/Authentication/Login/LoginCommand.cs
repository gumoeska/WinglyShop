using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.DTOs;

namespace WinglyShop.Application.Authentication.Login;

public sealed record LoginCommand(string logIn, string password) : ICommand<LoginUserResultDTO>;
