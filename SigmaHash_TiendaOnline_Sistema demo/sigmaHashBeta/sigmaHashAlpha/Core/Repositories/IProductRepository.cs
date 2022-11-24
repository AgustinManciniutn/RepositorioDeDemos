using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories;

public interface IProductListRepository : IGenericRepository<ProductList>
{
    Task<List<ProductList>> GetAll();
    Task<List<ProductList>> GetAllProducts();
    Task<ProductList> GetById(string id);
    Task<bool> Add(ProductList Entity);
    Task<bool> Delete(string id);
    Task<bool> Upsert(ProductList Entity, string id);
}
