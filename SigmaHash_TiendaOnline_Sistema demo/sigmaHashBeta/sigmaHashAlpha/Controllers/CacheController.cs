using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class CacheController : StoreCache<ProductList>
    {
        private readonly IUnitOfWork<ProductList> uow;
        private readonly IMemoryCache memoryCache;
        private readonly ILogger<ProductList> logger;
        private readonly IWebHostEnvironment _hostEnvironment;


        public CacheController(IUnitOfWork<ProductList> unitofwork, IMemoryCache memoryCache, ILogger<ProductList> _logger, IWebHostEnvironment hostEnvironment) : base(memoryCache, unitofwork)
        {
            this.memoryCache = memoryCache;
            this.uow = unitofwork;
            logger = _logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<bool> CacheClear()
        {
            return await ClearCache();  
        }
        public async Task<bool> ResetCache()
        {
            var cache = await GetCachedProducts();
            return true;
        }


    }
}
