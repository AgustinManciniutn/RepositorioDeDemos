using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class MOTController : GenericController<Motherboard>
    {

        public MOTController(IUnitOfWork<Motherboard> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<Motherboard>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
