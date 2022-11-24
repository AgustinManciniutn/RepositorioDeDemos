using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class CASController : GenericController<Case>
    {

        public CASController(IUnitOfWork<Case> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<Case>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
