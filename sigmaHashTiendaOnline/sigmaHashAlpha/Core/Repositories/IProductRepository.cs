using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Core.Repositories;

public interface IProductListRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetAll();
    Task<List<Product>> GetAllProducts();
    Task<Product> GetById(string id);
    Task<bool> Add(Product Entity);
    Task<bool> Delete(string id);
    Task<bool> Upsert(Product Entity, string id);
}
