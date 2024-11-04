using CQRS.Interfaces;
using CQRS.Model;
using CQRS.Queries.QueryModel;

namespace CQRS.Handlers;

public class UpdateProductCommandHandler(IRepository<Product> repository) : ICommandHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand command) { 
        var productToUpdate = await repository.GetByIdAsync(command.Id);
        productToUpdate.Name = command.Name;await repository.UpdateAsync(productToUpdate);
    }
}
