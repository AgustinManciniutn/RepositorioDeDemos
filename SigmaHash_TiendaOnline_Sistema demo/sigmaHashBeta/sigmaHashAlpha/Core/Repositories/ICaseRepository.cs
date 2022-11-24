using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface ICaseRepository : IGenericRepository<Case>
    {
        Task<List<Case>> GetAll();
        Task<Case> GetById(string id);
        Task<bool> Add(Case Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(Case Entity, string id);
    }
}
