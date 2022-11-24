using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class RAMRepository : GenericRepository<RAM>, IRAMRepository
    {
        public RAMRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
