using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class MOUController : GenericController<Mouse>
    {

        public MOUController(IUnitOfWork<Mouse> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<Mouse>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
