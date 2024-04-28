using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.OrderDetail;

public class OrderDetail : BaseEntity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int AddressId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
