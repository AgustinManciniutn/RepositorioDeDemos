using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Dictionary;
using sigmaHashAlpha.Models.Filter;
using sigmaHashAlpha.Models.ViewModels.CriteriaViewModel;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Utilities
{
    public class Cache : ICache
    {
        private const string KEY = "ProductsCache";
        private const string FILTERKEY = "FilterCache";
        private const string NOVELTY = "Novelty";
        private const string CAT = "Categories";
        private const string ATTR = "Attributes";
        private const string ATTRVALUES = "AttributeValues";
        private const string CATANDATTS = "CategoryAndAttributesIds";

        private readonly IMemoryCache memoryCache;
        private readonly ApplicationDbContext db;
        private readonly IUnitOfWork uow;
        private readonly IFiltering Filter;
        public Cache(IMemoryCache MemoryCache, IUnitOfWork unitofwork, IFiltering filter, ApplicationDbContext db)
        {
            memoryCache = MemoryCache;
            uow = unitofwork;
            Filter = filter;
            this.db = db;
        }

        public void AddToCache(Product prod)
        {
            var cache = memoryCache.Get(KEY) as List<Product>;
            if (cache == null)
            {
                cache = new List<Product>();
            }
            cache.Add(prod);
            memoryCache.Remove(KEY);
            memoryCache.Set(KEY, cache);
        }


        public void RemoveFromCache(Product prod)
        {
            var cache = memoryCache.Get(KEY) as List<Product>;

            var ToDelete = cache.FirstOrDefault(x => x.ProductId == prod.ProductId);

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

        public void UpdateFromCache(Product prod)
        {
            if(prod != null)
            {
                var cache = memoryCache.Get(KEY) as List<Product>;
                var toUpdate = cache.FirstOrDefault(x => x.ProductId == prod.ProductId);
                var toUpdateIndex = cache.FindIndex(x => x.ProductId == prod.ProductId);

                cache.Remove(toUpdate);
                cache.Insert(toUpdateIndex, prod);

                memoryCache.Remove(KEY);
                memoryCache.Set(KEY, cache);
            }
        }

        public async Task<bool> ClearCache()
        {
            List<Product> emptylist = null;
            memoryCache.Set(KEY, emptylist);
            return true;
        }


        public async Task<List<Product>> GetCachedProducts()
        {
            List<Product> products = new List<Product>();
            if (!memoryCache.TryGetValue(KEY, out products) || products == null)
            {
                products = await db.Products.ToListAsync();
                if (products != null)
                {
                    memoryCache.Set(KEY, products);
                }
                else
                {
                    products = new List<Product>();
                    memoryCache.Set(KEY, products);
                }
            }
            products = memoryCache.Get(KEY) as List<Product>;

            return products;
        }

        public async Task<List<Product>> GetFilteredProducts(Criteria criteria)
        {
            List<Product> products = new List<Product>();
            if (!memoryCache.TryGetValue(KEY, out products) || products == null)
            {
                products = await db.Products.ToListAsync();
                if (products == null)
                {
                    products = new List<Product>();
                    memoryCache.Set(KEY, products);
                    return products;
                }
                memoryCache.Set(KEY, products);
                return products;
            }
            products = await Filter.Filter(criteria, products);
            return products;
        }

        public void Novelty()
        {
            memoryCache.Set(NOVELTY, true);
        }
        public void NoNovelty()
        {
            memoryCache.Set(NOVELTY, false);
        }
        public async Task<bool> TryGetNovelty()
        {
            var check = memoryCache.Get(NOVELTY);

            if(check is true)
            {
                var attrs = await db.Attributes.ToListAsync();

                //var attrIds = attrs.Select(x => x.AttributeId).OrderBy(x => x).ToListA();

                
                List<Tuple<int, List<string>>> IdAndValues = new();
                 var list = await db.ProductAttributes.GroupBy(x => x.Value).Select(g => g.First()).ToListAsync();

                foreach(var item in list)
                {
                    Tuple<int, List<string>> IdValue = new Tuple<int, List<string>>(item.AttributeId,
                        
                        list.Where(x=> x.AttributeId == item.AttributeId).Select(x => x.Value).ToList());
                    if(IdAndValues != null)
                    IdAndValues.Add(IdValue);
                }

                var cats = await db.Categories.OrderBy(x=>x.CategoryId).ToDictionaryAsync(
                    x=> x.CategoryId, x=> x.Name);
                memoryCache.Set(CAT, cats);
                memoryCache.Set(ATTR, attrs.ToDictionary(x => x.AttributeId, x => x.AttrName));
                memoryCache.Set(ATTRVALUES, IdAndValues);
                NoNovelty();

                List<Tuple<int, int>> catattIds = await db.Attributes.Select(x => Tuple.Create(x.CategoryId, x.AttributeId)).ToListAsync();
                memoryCache.Set(CATANDATTS, catattIds);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Dictionary<int, string>> GetCategories()
        {
            Dictionary<int, string> catlist = new();
            await TryGetNovelty();
            if (!memoryCache.TryGetValue(CAT, out catlist))
            {
                var cats = await db.Categories.OrderBy(x => x.CategoryId).ToDictionaryAsync(
                    x => x.CategoryId, x => x.Name);
                memoryCache.Set(CAT, cats);
                return cats;
            }
            else
            {
                catlist = memoryCache.Get(CAT) as Dictionary<int,string>;
                return catlist ?? new Dictionary<int, string>();
            }
        }
        public async Task<Dictionary<int,string>> GetAttributes(int? catid)
        {
            Dictionary<int, string> attrlist = new();
            await TryGetNovelty();
            if (!memoryCache.TryGetValue(ATTR, out attrlist))
            {
                var obj = await db.Attributes.OrderBy(x=>x.AttributeId).ToDictionaryAsync
                    (x => x.AttributeId, x => x.AttrName);
                memoryCache.Set(ATTR, obj);
                attrlist = obj;
            }
            attrlist = memoryCache.Get(ATTR) as Dictionary<int,string>;
            if (catid == null || catid.Value == null)
                    return attrlist;
            
            var idids = await GetCatAttIds();
             idids = idids.Where(x => x.Item1 == catid).Select(x => Tuple.Create(x.Item1, x.Item2)).ToList();

            var result = attrlist.Where(p => idids.Select(x=> x.Item2).ToList().Contains(p.Key)).ToDictionary(p => p.Key, p => p.Value);  
            

            return result;



        }
        public async Task<List<Tuple<int, int>>> GetCatAttIds()
        {
            List<Tuple<int, int>> list = new();
            if (!memoryCache.TryGetValue(CATANDATTS, out list) || await TryGetNovelty())
            {
                List<Tuple<int, int>> catattIds = await db.Attributes.Select(x => Tuple.Create(x.CategoryId, x.AttributeId)).ToListAsync();

                memoryCache.Set(CATANDATTS, catattIds);
                list = catattIds;
                return list;
            }
            list = memoryCache.Get(CATANDATTS) as List<Tuple<int, int>>;
            return list ?? new List<Tuple<int,int>>();
        }


        public async Task<List<Subcategory>> GetProductAttributes(int? catid)
        {
            if(catid == null)
            {
                return new List<Subcategory>();
            }
            List<Subcategory> attrlist = new();

            await TryGetNovelty();
            if (!memoryCache.TryGetValue(ATTRVALUES, out attrlist))
            {
                var obj = await db.ProductAttributes.Select(x => new { x.AttributeId, x.Value }).Distinct().ToListAsync();
                attrlist = new();
                foreach (var item in obj)
                {
                    var subcat = new Subcategory(item.AttributeId,
                                                 item.Value,
                                                 obj.Where(x => x.AttributeId == item.AttributeId && x.Value == item.Value).ToList().Count()
                                                 );
                    attrlist.Add(subcat);
                }
                memoryCache.Set(ATTRVALUES, obj);

                List<Tuple<int,int>> catattIds = await db.Attributes.Select(x => Tuple.Create(x.CategoryId,x.AttributeId)).ToListAsync();
                memoryCache.Set(CATANDATTS, catattIds);
            }

            var idids = await GetCatAttIds();
            idids = idids.Where(x => x.Item1 == catid).Select(x => Tuple.Create(x.Item1, x.Item2)).ToList();

            return attrlist.Where(x => idids.Select(x => x.Item2).ToList().Contains(x.Id)).ToList();


        }
    }
}
