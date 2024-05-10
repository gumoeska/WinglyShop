using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Application.Categories.DTOs;

public sealed class CategoryDTO
{
	public string? Code { get; set; }
	public string? Description { get; set; }
	public bool? IsActive { get; set; }
}
