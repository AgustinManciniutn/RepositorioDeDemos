using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Core.Repositories
{
    public interface IMonitorRepository : IGenericRepository<GMonitor>
    {
        Task<List<GMonitor>> GetAll();
        Task<GMonitor> GetById(string id);
        Task<bool> Add(GMonitor Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(GMonitor Entity, string id);
    }
}
