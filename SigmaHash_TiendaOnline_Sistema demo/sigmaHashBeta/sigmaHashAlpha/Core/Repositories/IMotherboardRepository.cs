using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IMotherboardRepository : IGenericRepository<Motherboard>
    {
        Task<List<Motherboard>> GetAll();
        Task<Motherboard> GetById(string id);
        Task<bool> Add(Motherboard Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(Motherboard Entity, string id);
    }
}
