using CQRS.Interfaces;
using CQRS.Model;
using CQRS.Queries.CommandModel;

namespace CQRS.Handlers;

public class CreateProductCommandHandler(IRepository<Product> repository) : ICommandHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand command)
    {
        var product = new Product { Name = command.Name, Price = command.Price }; 
        await repository.AddAsync(product);await repository.SaveAsync();
    }
}