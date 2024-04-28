using WinglyShop.Domain.Common;
using WinglyShop.Domain.Common.Enums.Order;
using WinglyShop.Domain.Common.Enums.Payment;

namespace WinglyShop.Domain.Entities.Order;

public class Order : BaseEntity
{
	public int UserId { get; set; }
	public int DeliveryId { get; set; }
	public OrderStatus Status { get; set; }
	public PaymentMethod PaymentMethod { get; set; }
	public DateTime OrderDate { get; set; }
	public decimal TotalValue { get; set; }
}
