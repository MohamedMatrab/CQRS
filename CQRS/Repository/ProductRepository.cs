using CQRS.Data;
using CQRS.Interfaces;
using CQRS.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Repository;

public class ProductRepository(ApplicationDbContext dbContext) : IRepository<Product>
{
    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product!=null)
            return product;
        throw new Exception("Product is null !");
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task AddAsync(Product entity)
    {
        await dbContext.Products.AddAsync(entity);
    }

    public async Task UpdateAsync(Product entity)
    {
        dbContext.Products.Update(entity);
    }

    public async Task DeleteAsync(Product entity)
    {
        dbContext.Set<Product>().Remove(entity);
    }

    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}