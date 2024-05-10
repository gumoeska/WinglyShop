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

    public Task<Result<bool>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
        if (command is null)
        {
			throw new ArgumentNullException(nameof(command));
		}

        var product = new Product(command.Product);

        try
        {

        }
        catch (Exception ex)
        {

        }
	}
}
