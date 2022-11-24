using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class CaseRepository : GenericRepository<Case>, ICaseRepository
    {

        public CaseRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
