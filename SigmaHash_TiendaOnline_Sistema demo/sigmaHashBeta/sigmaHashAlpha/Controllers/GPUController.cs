using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Controllers
{
    public class GPUController : GenericController<GPU>
    {
        private readonly ApplicationDbContext db;
        public GPUController(IUnitOfWork<GPU> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<GPU>> _logger, IWebHostEnvironment hostEnvironment)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {

        }

    }
}
