using sigmaHashAlpha.Models;


namespace sigmaHashAlpha.Core.Repositories
{
    public interface IProductImagesRepository : IGenericRepository<ProductImage>
    {
        Task<List<string>> ProdAllImages(string id);
        Task<string> GetMainImage(string ProdId);
        Task<bool> DeleteAllImages(string prodId);
        Task<bool> UpsertProductImage(string id, string path);
    }
}
