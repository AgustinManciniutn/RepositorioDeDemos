
namespace sigmaHashAlpha.Core.Repositories
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        Task CompleteAsync();
        IProductListRepository Products { get; }
        IMotherboardRepository Motherboards { get; }
        ICPURepository Cpus { get; }
        IRAMRepository Rams { get; }
        IGPURepository Gpus { get; }
        IPSURepository Psus { get; }
        IMonitorRepository Monitors { get; }
        IStorageRepository Storages { get; }
        ICaseRepository Cases { get; }
        IMouseRepository Mouses { get; }
        IKeyboardRepository Keyboards { get; }
        IMiscellaneousRepository Miscellaneous { get; }
        IProductImagesRepository ProductImages { get; }
        IGenericRepository<T> Repository { get; }
        
    }
}
