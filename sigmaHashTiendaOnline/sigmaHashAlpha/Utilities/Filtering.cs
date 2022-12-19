using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Core.IUtilities;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Filter;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Utilities
{
    public class Filtering : IFiltering
    {
        private readonly IUnitOfWork uowF;
        private readonly ApplicationDbContext db;
        private readonly ISorter sorter;
        public Filtering( IUnitOfWork unitofwork,ApplicationDbContext db, ISorter sorter)
        {
            this.uowF = unitofwork;
            this.db = db;
            this.sorter = sorter;
        }

        public async Task<List<Product>> Filter(Criteria criteria, List<Product> cache)
        {

            if(criteria.SearchFilter != null)
            {
                cache = await SearchBar(criteria.SearchFilter, cache);
                return cache;
            }

            if (criteria.Category != null)
                cache = await Category(criteria.Category, cache);
            if (criteria.SelectedAttributes != null && criteria.SelectedAttributes.Count > 0)
                cache = await SubCategory(criteria.SelectedAttributes, cache);
            if (criteria.MinPrice != null || criteria.MaxPrice != null)
                cache = MinMaxPrice(criteria.MinPrice, criteria.MaxPrice, cache);

            if(criteria.Sort != null)
            {
                sorter.Sort(criteria.Sort, ref cache, criteria.SortReverse ?? false);
            }

            return cache ?? new List<Product>();
        }

        public async Task<List<Product>> Category(string category, List<Product> cache)
        {
            if (category != null)
            {
                cache = cache.Where(p => p.Category == category).ToList();
            }
            return cache;
        }

        public async Task<List<Product>> SubCategory(List<Subcategory> filters, List<Product> cache)
        {
            var temp = new List<Product>();
            if(filters != null)
            {
                List<List<Product>> ListOfProductList = new();
                foreach (var filter in filters)
                {
                    var ProdDetails = await db.ProductAttributes.Where(x => x.AttributeId == filter.Id
                    && x.Value == filter.Value).OrderBy(x => x.ProductId).ToListAsync();
                    
                    temp = cache.Where(x => ProdDetails.All(y => y.ProductId == x.ProductId)).ToList();
                    ListOfProductList.Add(temp);
                }
                var intersect = ListOfProductList.SelectMany(x => x).Distinct().Where(w => ListOfProductList.TrueForAll(t => t.Contains(w))).ToList();
                cache = intersect ?? new List<Product>();
            }
            return cache ?? new List<Product>();
        }

        public List<Product> MinMaxPrice(decimal? min, decimal? max, List<Product> cache)
        {
            if(min != null)
            {
                cache.RemoveAll(x => x.Price < min);
            }
            if(max != null)
            {
                cache.RemoveAll(x => x.Price > max);
            }
            return cache;
        }

        public async Task<List<Product>> SearchBar(string filter, List<Product> cache)
        {
            cache = cache.Where(p =>
                    p.ProductId == filter ||
                    p.Brand.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
                    p.Model.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
                    p.Category!.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1
            ).ToList();

            return cache ?? new List<Product>();
        }
    }
}
