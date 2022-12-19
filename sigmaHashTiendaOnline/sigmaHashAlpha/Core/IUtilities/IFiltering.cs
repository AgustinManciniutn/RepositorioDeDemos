
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Filter;


namespace sigmaHashAlpha.Utilities.IUtilities
{
    public interface IFiltering
    {
        Task<List<Product>> Filter(Criteria criteria, List<Product> cache);
        Task<List<Product>> Category(string category, List<Product> cache);
        List<Product> MinMaxPrice(decimal? min, decimal? max, List<Product> cache);
        Task<List<Product>> SearchBar(string filter, List<Product> cache);
    }
}