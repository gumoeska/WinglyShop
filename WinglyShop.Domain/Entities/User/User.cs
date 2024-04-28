using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.User;

public class User : BaseEntity
{
    public int AccountId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Image { get; set; }
}
