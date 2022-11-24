using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class PSUController : GenericController<PSU>
    {

        public PSUController(IUnitOfWork<PSU> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<PSU>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
