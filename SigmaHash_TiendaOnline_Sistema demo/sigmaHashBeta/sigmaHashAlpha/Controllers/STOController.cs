using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class STOController : GenericController<Storage>
    {

        public STOController(IUnitOfWork<Storage> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<Storage>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
