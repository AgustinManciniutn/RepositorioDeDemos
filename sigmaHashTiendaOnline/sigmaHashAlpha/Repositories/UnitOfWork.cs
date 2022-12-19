using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;

namespace sigmaHashAlpha.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

     
        public IProductListRepository Products { get; set; }
        public IProductImagesRepository ProductImages { get; set; }
    
        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Products = new ProductListRepository(_context, _logger);
            ProductImages = new ProductImageRepository(_context, _logger); 
        }

           


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }


    }
}
