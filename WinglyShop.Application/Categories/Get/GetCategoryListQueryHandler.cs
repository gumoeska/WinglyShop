﻿using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Shared;
using WinglyShop.Shared.Extensions;

namespace WinglyShop.Application.Categories.Get;

internal sealed class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<Category>>
{
    private readonly IDatabaseContext _context;

    public GetCategoryListQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<List<Category>>> Handle(GetCategoryListQuery query, CancellationToken cancellationToken)
    {
        var categoryList = await _context.Categories
            .AsNoTracking()
            .ToListAsync();

        if (categoryList.IsNullOrEmpty())
        {
            return Result.Failure<List<Category>>(new Error("Error", "Ocorreu um erro."));
        }

        return Result.Success(categoryList);
    }
}
