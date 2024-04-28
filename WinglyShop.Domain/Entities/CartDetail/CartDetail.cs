using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.CartDetail;

public class CartDetail : BaseEntity
{
	public int CartId { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; } // Valor total do mesmo produto por quantidade
}
