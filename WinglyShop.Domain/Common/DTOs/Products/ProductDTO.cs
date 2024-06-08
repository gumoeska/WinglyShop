namespace WinglyShop.Domain.Common.DTOs.Products;

public sealed class ProductDTO
{
	public int Id { get; set; }
	public string Code { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public bool HasStock { get; set; }
	public bool IsActive { get; set; }
	public int IdCategory { get; set; }
}
