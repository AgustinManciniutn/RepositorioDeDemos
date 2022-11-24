using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;

namespace sigmaHashAlpha.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IMotherboardRepository Motherboards { get; set; }
        public ICPURepository Cpus { get; set; }
        public IRAMRepository Rams { get; set; }
        public IGPURepository Gpus { get; set; }
        public IPSURepository Psus { get; set; }
        public IMonitorRepository Monitors { get; set; }
        public IStorageRepository Storages { get; set; }
        public ICaseRepository Cases { get; set; }
        public IMouseRepository Mouses { get; set; }
        public IKeyboardRepository Keyboards { get; set; }
        public IMiscellaneousRepository Miscellaneous { get; set; }
        public IProductListRepository Products { get; set; }
        public IProductImagesRepository ProductImages { get; set; }
        public IGenericRepository<T> Repository { get; set; }
    

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Motherboards = new MotherboardRepository(_context, _logger);
            Cpus = new CPURepository(_context, _logger);
            Rams = new RAMRepository(_context, _logger);
            Gpus = new GPURepository(_context, _logger);
            Psus = new PSURepository(_context, _logger);
            Monitors = new MonitorRepository(_context, _logger);
            Storages = new StorageRepository(_context, _logger);
            Cases = new CaseRepository(_context, _logger);
            Mouses = new MouseRepository(_context, _logger);
            Keyboards = new KeyboardRepository(_context, _logger);
            Miscellaneous = new MiscellaneousRepository(_context, _logger);
            Products = new ProductListRepository(_context, _logger);
            Repository = new GenericRepository<T>(_context, _logger);
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
