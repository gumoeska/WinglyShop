namespace WinglyShop.Application.Order.GetOrder;

public record GetOrderRequest(int userId, Guid userToken, int orderId);
