using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.GetById;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
{
    private readonly IDatabaseContext _context;

    public GetProductByIdQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<Product>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // Validation
        if (query is null)
        {
            return Result.Failure<Product>(new Error("Error", "Ocorreu um erro ao buscar o produto selecionado."));
        }

        // Getting the product by id
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id);

        // Finding the Category of the product by id
        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == product.IdCategory.GetValueOrDefault(0));

        // Validate the Product/Category
        if (product is null && category is null)
        {
            return Result.Failure<Product>(new Error("Error", "Ocorreu um erro ao buscar o produto selecionado."));
        }

        // Setting the description
        product.CategoryDescription = category.Description;

        return Result.Success(product);
    }
}
