using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using sigmaHashAlpha.Utilities;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Controllers
{
    public class StockController : Controller
    {

        private readonly ICache Cache;
        private readonly IFiltering Filter;
        private readonly IPaging Paging;
        private readonly IUnitOfWork<ProductList> uow;

        public StockController(IUnitOfWork<ProductList> unitofwork, ICache cache, IFiltering filter, IPaging paging) 
        {
            Cache = cache;
            Filter = filter;
            Paging = paging;
            uow = unitofwork;
        }

        public async Task <IActionResult> Index()
        {
            var cache = await Cache.GetCachedProducts();

            ListAndFilter model = new ListAndFilter();
            model.List = new();

            if (cache == null)
            {
                model.List = new List<ProductList>();
                model.PageCount = 1;
                return View("Index", model);
            }
            else
            {
               
                model.List = Paging.paging(cache, 0, ref model);
                return View("Index", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStock(string id, int amount)
        {
            try
            {
                var cache = Cache.GetCachedProducts();
                var prod = await uow.Products.GetById(id);

                if (prod != null)
                {
                    var check = prod.Stock + amount;
                    if(check < 0)
                    {
                        prod.Stock = 0;
                    }
                    else
                    {
                        prod.Stock += amount;
                    }
                    
                    await uow.Products.Upsert(prod, prod.Id!);
                    Cache.UpdateFromCache(prod);
                    TempData["success"] = "Stock has been updated"; 
                }
                else
                {
                    TempData["error"] = "Could not update the stock";
                    return PartialView("_Notification");
                }
                ViewData["success"] = "Stock has been updated";
                await uow.CompleteAsync();
                return PartialView("_Notification");
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message.ToString());
                TempData["error"] = "Stock controller error, AddStock method";
                return View("Error");
            }
        }

        public async Task<IActionResult> ResetStock(string id)
        {
            try
            {
                var cache = Cache.GetCachedProducts();
                var prod = await uow.Products.GetById(id);

                if (prod != null)
                {
                    prod.Stock = 0;
                    await uow.Products.Upsert(prod, prod.Id!);
                    Cache.UpdateFromCache(prod);
                    TempData["success"] = "Stock has been set to 0";

                }
                else
                {
                    TempData["error"] = "Could not update the stock";
                    return PartialView("_Notification");
                }

                await uow.CompleteAsync();
                return PartialView("_Notification");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
                TempData["error"] = "Stock controller error, ResetStock method";
                return View("Error");
            }
        }

        public async Task<IActionResult> SideBarSearch(string filter)
        {
            var model = await Filter.SideBarSearch(filter);
            return View("Index", model);
        }
        public async Task<IActionResult> Searchbar(string filter)
        {
            ListAndFilter obj = await Filter.SearchBar(filter);
   

            return View("Index", obj);
        }

        [HttpPost]
        public async Task <IActionResult> Criteria(string criteria)
        {
            ListAndFilter model = new();
            var cache = await Cache.GetCachedProducts();
            if(criteria == "stockasc")
            {
                model.List = cache.OrderBy(o => o.Stock).ToList();
                
            }
            else if(criteria == "stockdec")
            {
              
                model.List = cache.OrderBy(o => o.Stock).Reverse().ToList();
            }
            else if(criteria == "category")
            {
                model.List = cache.OrderBy(o => o.Category).ToList();
            }
            return RedirectToAction("Redirect", "Stock", new {list = model.List});
        }

        public async Task<IActionResult> CriteriaCategory(string criteria)
        {
            ListAndFilter model = new();
            model.List = await Cache.GetCachedProducts();
           model.List =  model.List.OrderBy(o => o.Category).ToList();
            return View("index", model);
        }

        public async Task<IActionResult> CriteriaStockUp(string criteria)
        {
            ListAndFilter model = new();
            model.List = await Cache.GetCachedProducts();
            model.List = model.List.OrderBy(o => o.Stock).ToList();
            TempData["criteria"] = "stockasc";
            return View("index", model);
        }

        public async Task<IActionResult> CriteriaStockDown(string criteria)
        {
            ListAndFilter model = new();
            model.List = await Cache.GetCachedProducts();
            model.List = model.List.OrderBy(o => o.Stock).Reverse().ToList();
            TempData["criteria"] = "stockdec";
            return View("index", model);
        }


        public async Task<IActionResult> CriteriaBrand()
        {
            ListAndFilter model = new();
            model.List = await Cache.GetCachedProducts();
            model.List = model.List.OrderBy(o => o.Brand).ToList();
            return View("index", model);
        }

    }
}
