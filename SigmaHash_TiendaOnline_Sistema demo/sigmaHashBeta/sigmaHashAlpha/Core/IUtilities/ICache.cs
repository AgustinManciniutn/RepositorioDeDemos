using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Utilities.IUtilities
{
    public interface ICache
    {
        void AddToCache(ProductList prod);
        void RemoveFromCache(ProductList prod);
        void UpdateFromCache(ProductList prod);
        Task<List<ProductList>> GetCachedProducts();


    }
}
