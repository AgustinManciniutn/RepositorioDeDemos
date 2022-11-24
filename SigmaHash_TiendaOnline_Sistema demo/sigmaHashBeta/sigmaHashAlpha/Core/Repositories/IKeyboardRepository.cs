using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IKeyboardRepository : IGenericRepository<Keyboard>
    {
        Task<List<Keyboard>> GetAll();
        Task<Keyboard> GetById(string id);
        Task<bool> Add(Keyboard Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(Keyboard Entity, string id);
    }
}
