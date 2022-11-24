using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IMiscellaneousRepository : IGenericRepository<Miscellaneous>
    {
        Task<List<Miscellaneous>> GetAll();
        Task<Miscellaneous> GetById(string id);
        Task<bool> Add(Miscellaneous Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(Miscellaneous Entity, string id);
    }
}
