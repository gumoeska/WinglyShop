using System;
using System.Collections.Generic;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Domain.Entities.Categories;

public partial class Category
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
