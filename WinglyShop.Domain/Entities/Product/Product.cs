using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool HasStock { get; set; }

    public int CategoryId { get; set; }
}
