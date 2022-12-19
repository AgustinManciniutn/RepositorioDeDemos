using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Filter;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Utilities
{
    public class Paging : IPaging
    {
        private const int limit = 65;
        private readonly ICache Cache;

        public Paging(ICache cache)
        {
            Cache = cache;
        }

        public List<Product> paging(List<Product> input, int card, ref Criteria criteria)
        {

            if(input != null)
            {
                if (input.Count() < limit)
                {
                    criteria.PageCount = 0;
                    return input;
                }
                int pages = input.Count() / limit;

                if (pages == 0) { pages = 1; };

                if (input.Count() % limit != 0) { pages += 1; }
                criteria.PageCount = pages;
                var result = input.Skip(limit * card - card).Take(limit).ToList();

                return result;
            }
            else
            {
                return new List<Product>();
            }
                
        }



        //public async Task<ListAndFilter> Pages(ListAndFilter obj)
        //{
        //    var cache = await StoreCache.GetCachedProducts();

        //    if (obj.FilterText != null && obj.FilterText.Length > 0)
        //    {
        //        var filtered = cache.Where
        //        (
        //         p => p.Brand.IndexOf(obj.FilterText, StringComparison.OrdinalIgnoreCase) != -1 ||
        //         p.Category.IndexOf(obj.FilterText, StringComparison.OrdinalIgnoreCase) != -1 ||
        //         p.Model.IndexOf(obj.FilterText, StringComparison.OrdinalIgnoreCase) != -1 ||
        //         p.Id == obj.FilterText
        //        ).ToList();
        //        obj.List = paging(filtered, obj.Filter.Page, ref obj);
        //        obj.Filtered = true;
        //        obj.FilterText = obj.Filter.Filter;
        //    }
        //    else
        //    {
        //        obj.List = paging(cache, obj.Filter.Page, ref obj);
        //    }
        //    return obj;
        //}


    }
}
