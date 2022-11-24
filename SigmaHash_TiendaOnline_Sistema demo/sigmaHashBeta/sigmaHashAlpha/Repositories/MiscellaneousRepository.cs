using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class MiscellaneousRepository : GenericRepository<Miscellaneous>, IMiscellaneousRepository
    {

        public MiscellaneousRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
