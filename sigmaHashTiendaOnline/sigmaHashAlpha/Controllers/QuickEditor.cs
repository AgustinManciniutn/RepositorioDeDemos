using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Controllers
{
    public class QuickEditor : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ICache Cache;

        public QuickEditor(ApplicationDbContext db, ICache cache)
        {
            this.db = db;
            Cache = cache;
        }

        public async Task<IActionResult> Index(string id)
        {
            var obj = await db.Products.FindAsync(id);
            if(obj != null)
            {   
                obj.ProductAttributes = await db.ProductAttributes.Where(x => x.ProductId == id).ToListAsync() ?? new List<ProductAttribute>();

            }

            return View();
        }
    }
}
