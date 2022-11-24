using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class PSURepository : GenericRepository<PSU>, IPSURepository
    {
        public PSURepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
