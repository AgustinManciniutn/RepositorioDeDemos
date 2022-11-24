using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IGPURepository : IGenericRepository<GPU>
    {
        Task<List<GPU>> GetAll();
        Task<GPU> GetById(string id);
        Task<bool> Add(GPU Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(GPU Entity, string id);
    }
}
