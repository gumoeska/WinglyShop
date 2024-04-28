using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.Category;

public class Category : BaseEntity
{
    public string Code { get; set; }
    public string Description { get; set; }
}
