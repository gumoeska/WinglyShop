using WinglyShop.Domain.Entities.OrderDetails;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Domain.Entities.Orders;

public partial class Order
{
    public int Id { get; set; }

    public int? Status { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? PaymentMethod { get; set; }

    public decimal? TotalValue { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
