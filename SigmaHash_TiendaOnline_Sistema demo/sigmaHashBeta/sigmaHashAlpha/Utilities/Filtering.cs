using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Utilities
{
    public class Filtering : IFiltering
    {
        private readonly StoreCache<ProductList> CacheF;
        private readonly IUnitOfWork<ProductList> uowF;

        public Filtering(StoreCache<ProductList> cache, IUnitOfWork<ProductList> unitofwork)
        {
            CacheF = cache;
            this.uowF = unitofwork;
        }

        public async Task<ListAndFilter> SideBarSearch(string filter)
        {
            ListAndFilter model = new ListAndFilter();
            var cache = await CacheF.GetCachedProducts();
            model.Filtered = true;
            model.FilterText = filter;
            model.PageCount = 0;
            if (filter.IndexOf("DDR", StringComparison.OrdinalIgnoreCase) != -1)
            {
                var filteredRams = new List<ProductList>();
                var ids = await uowF.Rams.GetAll();

                if (ids != null)
                {
                    var list = ids.Where(r => r.Type?.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    foreach (var obj in list)
                    {
                        var ram = cache.FirstOrDefault(r => r.Id == obj.Id);
                        if (ram != null)
                            filteredRams.Add(ram!);
                    }

                    model.List = filteredRams.ToList();
                    return model;
                }
                else
                {
                    return model;
                }
            }

            if (filter == "HDD" || filter == "SSD" || filter == "M.2")
            {
                var filteredStor = new List<ProductList>();
                var ids = await uowF.Storages.GetAll();
                var list = ids.Where(s => s.StorageType == filter).ToList();
                if (list != null)
                {
                    foreach (var obj in list)
                    {
                        var sto = cache.FirstOrDefault(s => s.Id == obj.Id);
                        if (sto != null)
                            filteredStor.Add(sto);
                    }
                    model.List = filteredStor.ToList();
                    return model;
                }
                else
                {
                    return model;
                }
            }

            var filtered = cache.Where
            (
             p => p.Brand.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Category.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Model.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Id == filter
            ).ToList();
            model.List = filtered.ToList();

            return model;
        }

        public async Task<ListAndFilter> SearchBar(string filter)
        {
            ListAndFilter obj = new();

            var cache = await CacheF.GetCachedProducts();
            obj.Filtered = true;

            if (filter == null)
            {
                obj.Filtered = false;
                obj.List = cache;
                return obj;
            }

            var filtered = cache.Where
            (
             p => p.Brand.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Category.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Model.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Id.Contains(filter)
            ).ToList();

            obj.FilterText = filter;

            obj.List = filtered;

            return obj;
          
        }

    }
}
