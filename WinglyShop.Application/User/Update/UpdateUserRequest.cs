namespace WinglyShop.Application.User.Update;

public record UpdateUserRequest(int accountId, string name, string surname, string image);
