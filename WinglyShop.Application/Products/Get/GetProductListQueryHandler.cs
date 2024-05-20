using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.Get;

internal sealed class GetProductListQueryHandler : IQueryHandler<GetProductListQuery, List<Product>>
{
    private readonly IDatabaseContext _context;

    public GetProductListQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<List<Product>>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
    {
        // Todo: implementar paginação (trazer valores da Query) {skip - take}

        var productList = await _context.Products.ToListAsync();

        if (productList.IsNullOrEmpty())
        {
            return Result.Failure<List<Product>>(new Error("Error", "An error occured"));
        }

        return Result.Success(productList);
    }
}
