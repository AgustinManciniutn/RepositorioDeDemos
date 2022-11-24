using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class MouseRepository : GenericRepository<Mouse>, IMouseRepository
    {
        public MouseRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
