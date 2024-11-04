using CQRS.Interfaces;
using CQRS.Model;
using CQRS.Queries.QueryModel;

namespace CQRS.Handlers;

public class GetProductsQueryHandler(IRepository<Product> repository)
    : IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>>
{
    public async Task<IEnumerable<GetAllProductCommand>> Handle(GetProductsQuery query) { 
        var products = await repository.GetAllAsync(); 
        // Implement repository method
        // Map products to ProductViewModel
        return products.Select(p => new GetAllProductCommand
        {
            Id = p.Id, Name = p.Name, Price = p.Price
        }); 
    } 
}