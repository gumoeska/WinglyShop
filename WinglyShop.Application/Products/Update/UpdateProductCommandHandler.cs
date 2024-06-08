﻿using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.Update;

internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, bool>
{
    private readonly IDatabaseContext _context;

    public UpdateProductCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var product = new Product(command.Product);

        try
        {
            var productToEdit = await _context.Products
                .Where(x => x.Id == product.Id)
                .FirstOrDefaultAsync();

            if (product is not null)
            {
                productToEdit.Description = product.Description;
                productToEdit.Code = product.Code;
                productToEdit.Price = product.Price;
                productToEdit.IdCategory = product.IdCategory;
                productToEdit.HasStock = product.HasStock;
                productToEdit.IsActive = product.IsActive;
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "Ocorreu um erro ao atualizar as informações do Produto."));
        }

        return Result.Success(true);
    }
}
