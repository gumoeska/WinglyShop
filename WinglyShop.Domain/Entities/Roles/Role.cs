using System;
using System.Collections.Generic;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Domain.Entities.Roles;

public partial class Role
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int? Access { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
