
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Infrastructure.ViewComponents
{
    public class UserSidebarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public UserSidebarViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
