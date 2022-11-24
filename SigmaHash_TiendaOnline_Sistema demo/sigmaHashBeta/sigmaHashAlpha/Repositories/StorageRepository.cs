using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class StorageRepository : GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
