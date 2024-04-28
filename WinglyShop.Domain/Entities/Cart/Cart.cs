using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.Cart;

public class Cart : BaseEntity
{
	public int UserId { get; set; }
	public decimal TotalValue { get; set; }
}
