using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, bool>
{
	private readonly IDatabaseContext _context;

    public CreateProductCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
        if (command is null)
        {
			throw new ArgumentNullException(nameof(command));
		}

        var product = new Product(command.Product);

        try
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "An error occured."));
		}

        return Result.Success(true);
	}
}
