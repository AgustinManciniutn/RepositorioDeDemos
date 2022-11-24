using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Repositories
{
    public class ProductListRepository : GenericRepository<ProductList>, IProductListRepository
    {
        public ProductListRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
            
        }

        public async Task<List<ProductList>> GetAllProducts()
        {
            List<ProductList> list = await dbSet.ToListAsync();
            return list;
        }

    }
}
