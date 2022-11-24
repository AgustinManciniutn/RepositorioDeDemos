using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure.Reservations;

namespace sigmaHashAlpha.Controllers
{
    

    public class UserController : Controller
    {

        private readonly ApplicationDbContext db;

        public UserController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Reservations()
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            var model = await db.UserReservations.Where(x => x.Id == user.Id).ToListAsync() ?? new List<User_Reservation>();

            return View(model);

        }

        public async Task<IActionResult> Purchases()
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            var model = await db.UserReservations.Where(x => x.Id == user.Id).ToListAsync() ?? new List<User_Reservation>();

            return View(model);
        }
    }
}
