using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class MONController : GenericController<GMonitor>
    {

        public MONController(IUnitOfWork<GMonitor> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<GMonitor>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
