namespace WinglyShop.Application.User.Create;

public record CreateUserRequest(int accountId, string name, string surname, string image);
