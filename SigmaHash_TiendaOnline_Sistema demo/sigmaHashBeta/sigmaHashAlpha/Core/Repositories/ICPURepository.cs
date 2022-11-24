using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories;

public interface ICPURepository : IGenericRepository<CPU>
{
    Task<List<CPU>> GetAll();
    Task<CPU> GetById(string id);
    Task<bool> Add(CPU Entity);
    Task<bool> Delete(string id);
    Task<bool> Upsert(CPU Entity, string id);
}