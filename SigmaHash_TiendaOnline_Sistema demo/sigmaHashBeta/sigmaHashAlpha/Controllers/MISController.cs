using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class MISController : GenericController<Miscellaneous>
    {

        public MISController(IUnitOfWork<Miscellaneous> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<Miscellaneous>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
