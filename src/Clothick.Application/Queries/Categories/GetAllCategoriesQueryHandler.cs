using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Queries.Categories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    private readonly IBaseRepository<Category> _categoryRepository;

    public GetAllCategoriesQueryHandler(IBaseRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return categories;
    }
}