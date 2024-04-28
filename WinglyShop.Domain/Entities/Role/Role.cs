using WinglyShop.Domain.Common;
using WinglyShop.Domain.Common.Enums.Account;

namespace WinglyShop.Domain.Entities.Role;

public class Role : BaseEntity
{
    public string Description { get; set; }
    public RoleAccess Access { get; set; }
}
