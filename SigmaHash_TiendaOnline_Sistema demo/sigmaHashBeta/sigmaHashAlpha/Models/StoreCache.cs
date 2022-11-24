using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using System.Collections.Generic;

namespace sigmaHashAlpha
{
    public class StoreCache<T> : Controller where T : class
    {
        private const string KEY = "ProductsCache";
        private readonly IMemoryCache memoryCache;
        private readonly IUnitOfWork<T> uow;
        
        public StoreCache(IMemoryCache memoryCache, IUnitOfWork<T> unitofwork) 
        {
            this.memoryCache = memoryCache;
            uow = unitofwork;
        }

        public void AddToCache(ProductList prod)
        {
            var cache = memoryCache.Get(KEY) as List<ProductList>;
            if(cache == null)
            {
                cache = new List<ProductList>();
            }
            cache.Add(prod);
            memoryCache.Remove(KEY);
            memoryCache.Set(KEY, cache);
        }


        public void RemoveFromCache(ProductList prod)
        {
            var cache = memoryCache.Get(KEY) as List<ProductList>;

            var ToDelete = cache.FirstOrDefault(x => x.Id == prod.Id);

            if (cache.Remove(ToDelete))
            {
                memoryCache.Remove(KEY);
                memoryCache.Set(KEY, cache);
            }
            else
            {
                throw new Exception("Test Exception");
            }
            
        }

        public void UpdateFromCache(ProductList prod)
        {
            var cache = memoryCache.Get(KEY) as List<ProductList>;
            var toUpdate = cache.FirstOrDefault(x => x.Id == prod.Id);
            var toUpdateIndex = cache.FindIndex(x => x.Id == prod.Id);

            cache.Remove(toUpdate);
            cache.Insert(toUpdateIndex, prod);

            memoryCache.Remove(KEY);
            memoryCache.Set(KEY, cache);

        }

        public async Task<bool> ClearCache()
        {
            List<ProductList> emptylist = null;
            memoryCache.Set(KEY, emptylist);
            return true;
        }


        public async Task<List<ProductList>> GetCachedProducts()
        {
            List<ProductList> products = new List<ProductList>();
            if (!memoryCache.TryGetValue(KEY, out products) || products == null) 
            {
                products = await uow.Products.GetAllProducts();
                if(products != null)
                {
                    memoryCache.Set(KEY, products);
                }
                else
                {
                    products = new List<ProductList>();
                    memoryCache.Set(KEY, products);
                }
            }
            products = memoryCache.Get(KEY) as List<ProductList>;

            return products;
        }
    }
}
