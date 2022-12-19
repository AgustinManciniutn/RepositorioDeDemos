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

        public async Task<IActionResult> UserReservations()
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            var reservIdList = await db.UserReservations.Where(x => x.Id == user.Id).Select(x=> x.ReservationId).ToListAsync() ?? new List<string>();
            var reservations = new List<Reservation>();
            if (reservIdList.Count() > 0)
            {
                 reservations = await db.Reservations.Where(x => reservIdList.Contains(x.ReservationId)).OrderBy(x=> x.IsExpired).ToListAsync() ?? new List<Reservation>();
            }
            var allitems = await db.ReservationItems.Where(x=> reservations.Select(r => r.ReservationId).ToList().Contains(x.ReservationItemId)).ToListAsync();
            List<ReservationAndItems> model = new();
            ReservationAndItems modelobj = new();
            foreach(var obj in reservations)
            {
                modelobj = new();
                modelobj.Reservation = obj;
                modelobj.Items = allitems.Where(x => x.ReservationItemId == obj.ReservationId).ToList();
                model.Add(modelobj);
            }

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
