using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Products.DTOs;

namespace WinglyShop.Application.Products;

public sealed record CreateProductCommand(ProductDTO Product) : ICommand<bool>;
