using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Products;

namespace WinglyShop.Application.Products;

public sealed record CreateProductCommand(ProductDTO Product) : ICommand<bool>;
