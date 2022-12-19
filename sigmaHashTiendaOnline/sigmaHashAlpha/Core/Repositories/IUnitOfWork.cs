
namespace sigmaHashAlpha.Core.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        Task CompleteAsync();
        IProductListRepository Products { get; }
        IProductImagesRepository ProductImages { get; }
       
    }
}
