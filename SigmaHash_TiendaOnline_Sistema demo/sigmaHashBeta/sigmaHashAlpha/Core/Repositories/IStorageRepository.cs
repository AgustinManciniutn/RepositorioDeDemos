using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IStorageRepository : IGenericRepository<Storage>
    {
        Task<List<Storage>> GetAll();
        Task<Storage> GetById(string id);
        Task<bool> Add(Storage Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(Storage Entity, string id);
    }
}
