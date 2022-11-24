using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class KeyboardRepository : GenericRepository<Keyboard>, IKeyboardRepository
    {
        public KeyboardRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
