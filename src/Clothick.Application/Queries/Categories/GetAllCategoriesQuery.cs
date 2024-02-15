using Clothick.Domain.Entities;
using MediatR;

namespace Clothick.Application.Queries.Categories;

public record GetAllCategoriesQuery(): IRequest<List<Category>>;