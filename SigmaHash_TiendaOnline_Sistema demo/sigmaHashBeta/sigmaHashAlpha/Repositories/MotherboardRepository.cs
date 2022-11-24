using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class MotherboardRepository : GenericRepository<Motherboard>, IMotherboardRepository
    {
        public MotherboardRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}