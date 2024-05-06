using WinglyShop.Domain.Entities.CartDetails;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Domain.Entities.OrderDetails;

namespace WinglyShop.Domain.Entities.Products;

public partial class Product
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public bool? HasStock { get; set; }

    public bool? IsActive { get; set; }

    public int? IdCategory { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
