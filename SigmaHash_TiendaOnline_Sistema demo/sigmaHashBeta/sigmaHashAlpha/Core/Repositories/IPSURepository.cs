using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IPSURepository : IGenericRepository<PSU>
    {
        Task<List<PSU>> GetAll();
        Task<PSU> GetById(string id);
        Task<bool> Add(PSU Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(PSU Entity, string id);
    }
}
