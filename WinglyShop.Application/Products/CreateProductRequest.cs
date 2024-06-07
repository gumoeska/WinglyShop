namespace WinglyShop.Application.Products;

public sealed record CreateProductRequest(
    string Code,
    string Description,
    decimal Price,
    bool HasStock,
    bool IsActive,
    int CategoryId);
