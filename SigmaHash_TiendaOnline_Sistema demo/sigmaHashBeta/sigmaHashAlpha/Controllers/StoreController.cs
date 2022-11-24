using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Data;

namespace sigmaHashAlpha.Controllers;

public class StoreController : Controller
{
    private readonly IMemoryCache _memoryCache;

    //public Store(IMemoryCache memoryCache, ApplicationDbContext context)
    //{
    //    this.memoryCache = memoryCache;
    //    this.context = context;
    //}


    public IActionResult StoreView()
    {
        return View("Store");
    }


    //public GetAllProducts(IMemoryCache memoryCache)
    //{
    //    List<Product> products;

    //    if(!memoryCache.TryGetValue("Products", out products))
    //    {
    //        memoryCache.Set("Products", context.Products.ToList());
    //    }

    //    products = memoryCache.Get("Products") as List<Product>;

    //}

}

