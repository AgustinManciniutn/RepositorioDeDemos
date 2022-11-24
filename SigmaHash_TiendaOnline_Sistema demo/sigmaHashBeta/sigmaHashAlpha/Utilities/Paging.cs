using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Utilities
{
    public class Paging : IPaging
    {
        private const int limit = 65;
        private readonly StoreCache<ProductList> StoreCache;

        public Paging(StoreCache<ProductList> cache)
        {
            StoreCache = cache;
        }

        public List<ProductList> paging(List<ProductList> input, int card, ref ListAndFilter listandfilter)
        {
            var list = input;
            if(list != null)
            {
                if (list.Count() < limit)
                {
                    listandfilter.PageCount = 0;
                    return list;
                }
                int pages = list.Count() / limit;

                if (pages == 0) { pages = 1; };

                if (list.Count() % limit != 0) { pages += 1; }
                listandfilter.PageCount = pages;
                var result = list.Skip(limit * card - card).Take(limit).ToList();

                return result;
            }
            else
            {
                return new List<ProductList>();
            }
                
        }



        public async Task<ListAndFilter> Pages(ListAndFilter obj)
        {
            var cache = await StoreCache.GetCachedProducts();

            if (obj.FilterText != null && obj.FilterText.Length > 0)
            {
                var filtered = cache.Where
                (
                 p => p.Brand.IndexOf(obj.FilterText, StringComparison.OrdinalIgnoreCase) != -1 ||
                 p.Category.IndexOf(obj.FilterText, StringComparison.OrdinalIgnoreCase) != -1 ||
                 p.Model.IndexOf(obj.FilterText, StringComparison.OrdinalIgnoreCase) != -1 ||
                 p.Id == obj.FilterText
                ).ToList();
                obj.List = paging(filtered, obj.Filter.Page, ref obj);
                obj.Filtered = true;
                obj.FilterText = obj.Filter.Filter;
            }
            else
            {
                obj.List = paging(cache, obj.Filter.Page, ref obj);
            }
            return obj;
        }


    }
}
