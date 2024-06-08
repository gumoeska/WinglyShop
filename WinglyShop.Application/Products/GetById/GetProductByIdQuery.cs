using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Application.Products.GetById;

public sealed record GetProductByIdQuery(int Id) : IQuery<Product>;
