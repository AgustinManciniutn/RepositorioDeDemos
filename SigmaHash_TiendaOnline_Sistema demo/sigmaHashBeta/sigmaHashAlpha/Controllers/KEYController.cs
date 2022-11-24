using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class KEYController : GenericController<Keyboard>
    {

        public KEYController(IUnitOfWork<Keyboard> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<Keyboard>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }
    }
}
