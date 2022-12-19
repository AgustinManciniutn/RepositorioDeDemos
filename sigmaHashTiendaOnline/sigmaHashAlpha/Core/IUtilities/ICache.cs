using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Dictionary;
using sigmaHashAlpha.Models.Filter;


namespace sigmaHashAlpha.Utilities.IUtilities
{
    public interface ICache
    {
        void AddToCache(Product prod);
        void RemoveFromCache(Product prod);
        void UpdateFromCache(Product prod);
        Task<List<Product>> GetCachedProducts();
        Task<List<Product>> GetFilteredProducts(Criteria criteria);
        public void Novelty();
        Task<bool> TryGetNovelty();
        Task<Dictionary<int, string>> GetAttributes(int? cat);
        Task<List<Subcategory>> GetProductAttributes(int? attrid);
        Task<Dictionary<int, string>> GetCategories();
    }
}
