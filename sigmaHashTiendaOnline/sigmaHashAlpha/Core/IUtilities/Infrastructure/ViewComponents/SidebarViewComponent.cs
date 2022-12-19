using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Infrastructure.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public SidebarViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> list = await db.Categories.ToListAsync() ?? new List<Category>();

            return View(list);

        }

    }
}
