using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Cart;

public sealed record AddProductCartCommand(int cartId, int productId, int quantity) : ICommand<bool>;
