using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class GPURepository : GenericRepository<GPU>, IGPURepository
    {
        public GPURepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
