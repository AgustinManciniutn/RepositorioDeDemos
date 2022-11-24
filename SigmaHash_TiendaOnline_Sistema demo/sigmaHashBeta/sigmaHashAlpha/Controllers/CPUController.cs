using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class CPUController : GenericController<CPU>
    {

        public CPUController(IUnitOfWork<CPU> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<CPU>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
