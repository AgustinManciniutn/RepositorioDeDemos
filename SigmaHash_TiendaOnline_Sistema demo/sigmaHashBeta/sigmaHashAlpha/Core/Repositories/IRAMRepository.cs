using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IRAMRepository : IGenericRepository<RAM>
    {
        Task<List<RAM>> GetAll();
        Task<RAM> GetById(string id);
        Task<bool> Add(RAM Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(RAM Entity, string id);
    }
}
