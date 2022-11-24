using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class CPURepository : GenericRepository<CPU>, ICPURepository
    {
        public CPURepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
