namespace WinglyShop.Application.Cart;

public record AddProductCartRequest(int cartId, int productId, int quantity);
