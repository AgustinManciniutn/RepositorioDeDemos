using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Architecture;


namespace sigmaHashAlpha.Repositories
{
    public class ProductListRepository : GenericRepository<Product>, IProductListRepository
    {
        public ProductListRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
            
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> list = await dbSet.ToListAsync();
            return list;
        }

    }
}
