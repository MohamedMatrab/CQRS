using CQRS.Interfaces;
using CQRS.Model;
using CQRS.Queries.CommandModel;
using CQRS.Queries.QueryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(
    ICommandHandler<CreateProductCommand> createProductCommandHandler,
    IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>> getProductsQueryHandler,
    ICommandHandler<UpdateProductCommand> updateProductCommandHandler,
    ICommandHandler<DeleteProductCommand> deleteProductCommandHandler)
    : ControllerBase
{
    [HttpPost(nameof(CreateProduct))]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        await createProductCommandHandler.Handle(command); return Ok();
    }

    [HttpGet(nameof(GetProducts))]
    public async Task<IActionResult> GetProducts()
    {
        var products = await getProductsQueryHandler.Handle(new GetProductsQuery()); return Ok(products);
    }

    [HttpPut(nameof(UpdateProduct))]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
    {
        try
        {
            await updateProductCommandHandler.Handle(command);
            return Ok("Product updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating product: {ex.Message}");
        }
    } 
    
    [HttpDelete(nameof(DeleteProduct))]
    public async Task<IActionResult> DeleteProduct(int productId) {
        try
        {
            var command = new DeleteProductCommand { Id = productId };
            await deleteProductCommandHandler.Handle(command);
            return Ok("Product deleted successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting product: {ex.Message}");
        }
    }
}
