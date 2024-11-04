using CQRS.Interfaces;
using CQRS.Model;
using CQRS.Queries.QueryModel;

namespace CQRS.Handlers;

public class DeleteProductCommandHandler(IRepository<Product> repository) : ICommandHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand command) { 
        var productToDelete = await repository.GetByIdAsync(command.Id);
        await repository.DeleteAsync(productToDelete);
    }
}