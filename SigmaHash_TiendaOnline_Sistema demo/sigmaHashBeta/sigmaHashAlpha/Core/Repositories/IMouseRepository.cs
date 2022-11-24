using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IMouseRepository : IGenericRepository<Mouse>
    {
        Task<List<Mouse>> GetAll();
        Task<Mouse> GetById(string id);
        Task<bool> Add(Mouse Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(Mouse Entity, string id);
    }
}
