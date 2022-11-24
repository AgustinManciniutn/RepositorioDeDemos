using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class RAMController : GenericController<RAM>
    {

        public RAMController(IUnitOfWork<RAM> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<RAM>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
