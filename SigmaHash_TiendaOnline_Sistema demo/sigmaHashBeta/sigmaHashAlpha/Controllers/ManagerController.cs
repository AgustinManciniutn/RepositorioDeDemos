using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure.Reservations;
using sigmaHashAlpha.Infrastructure.Roles;
using System.Collections.Generic;

namespace sigmaHashAlpha.Controllers;

//[Authorize(Policy = "ManagerOnly")]
public class ManagerController : Controller
{
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly ApplicationDbContext _context;

    public ManagerController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
        this.signInManager = signInManager;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    //[Authorize(Roles = "Manager")]
    public async Task<IActionResult> Admin()
    {
        AdminViewModel ViewModel = new();
        var roles = await _context.Roles.ToListAsync();
        var rolledusers = new List<UserRole>();

        var roledusers = await _context.RoledUsers.ToListAsync();
        
        foreach(var roleduser in roledusers)
        {
            UserRole UserRole = new();
            
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Id == roleduser.UserId);
            UserRole.Email = user.Email;
            var list = await _context.UserRoles.Where(x => x.UserId == roleduser.UserId).ToListAsync();
            if (list != null)
            {
                foreach (var role in list)
                {
                    var rol = await _context.Roles.FindAsync(role.RoleId);
                    UserRole.Roles.Add(rol.Name);
                }
            }
            ViewModel.RoledUsers.Add(UserRole);
        }
        ViewModel.Roles = new List<string>();

        if (roles != null)
        {
            foreach (var obj in roles)
            {
                ViewModel.Roles.Add(obj.Name);
            }
        }
        return View(ViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(AdminViewModel model)
    {
        if (model.PostUserEmail != null)
        {
            string email = model.PostUserEmail.ToUpper();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.NormalizedEmail == email);

            if (user == null)
            {
                TempData["error"] = "The user entered has not been found as a Registered User.";
                return RedirectToAction("Admin", "Manager");
            }

            var RolesToAdd = new List<string>();
            var RolesToRemove = new List<string>();

            if (model.Manager)
            {
                RolesToAdd.Add("Manager");
            }
            else { RolesToRemove.Add("Manager"); }
            if (model.Administrator)
            {
                RolesToAdd.Add("Administrator");
            }
            else { RolesToRemove.Add("Administrator"); }
            if (model.Assistant)
            {
                RolesToAdd.Add("Assistant");
            }
            else { RolesToRemove.Add("Assistant"); }

            foreach (var role in RolesToRemove)
            {
                await userManager.RemoveFromRoleAsync(user!, role);
                var claim = _context.UserClaims.FirstOrDefault(x => x.ClaimType == role);
                if (claim != null)
                    await userManager.RemoveClaimAsync(user, claim.ToClaim());
            }
            foreach (var role in RolesToAdd)
            {
                await userManager.AddToRoleAsync(user!, role);
            }

            var check = await _context.RoledUsers.FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (RolesToAdd.Any())
            {
                if(check == null)
                {
                    RoledUsers roleduser = new();
                    roleduser.UserId = user.Id;
                    await _context.RoledUsers.AddAsync(roleduser);
                }

            }
            else
            {
                var rows = await _context.RoledUsers.Where(x => x.UserId == user.Id).ToListAsync();
                _context.RoledUsers.RemoveRange(rows);
               
            }
            await _context.SaveChangesAsync();
            await signInManager.RefreshSignInAsync(user!);

            

            return RedirectToAction("Admin", "Manager");
        }
        TempData["error"] = "Error! Request was not successful.";
        return RedirectToAction("Admin", "Manager");
    }

    public async Task<IActionResult> Reservations()
    {
        List<Reservation> reservations = await _context.Reservations.Where(x=> !x.Archived).ToListAsync();
        
        if(reservations == null)
        {
            return View();
        }
        
        List<ReservationAndItems> model = new();
        
        foreach(var obj in reservations)
        {
            ReservationAndItems modelItem = new();

            modelItem.Reservation = obj;
            modelItem.Items = await _context.ReservationItems.Where(x => x.ReservationItemId == obj.ReservationId).ToListAsync();
            model.Add(modelItem);
        }
        
        return View(model);
    }



    public async Task<IActionResult> DownloadPDF(string Id)
    {
        try
        {
            var Reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == Id);

            if (Reservation == null)
            {
                return View("Error");
            }
            else
            {
                var file = Reservation.BankTransferReceipt;

                return File(file!, "application/pdf");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("ManagerController DownloadPDF exception");
            TempData["error"] = "PDF download request was unsuccesful, try again later.";
            return RedirectToAction("Reservations", "Manager");
        }


    }
    public async Task<IActionResult> FileReservation(string Id)
    {
        var reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == Id);

        if(reservation != null)
        {
            reservation.Archived = true;
            return new EmptyResult();
        }
        else
        {
            return View("Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> FileExpired()
    {
        try
        {
            List<Reservation> reservations = await _context.Reservations.Where(x => x.IsExpired).ToListAsync();
            if (reservations == null)
            {
                return RedirectToAction("Reservations");
            }
            else
            {
                foreach(var obj in reservations)
                {
                    obj.Archived = true;
                    _context.Reservations.Update(obj);
                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Reservations");
            }
        }
        catch(Exception ex)
        {

            Console.WriteLine("ManagerController FileExpired exception");
            TempData["error"] = "Request was unsuccesful, try again later.";
            return View("Error");

        }

    }

    [HttpPost]
    public async Task<IActionResult> ShowArchive()
    {
        try
        {
            List<Reservation> reservations = await _context.Reservations.Where(x => x.Archived).ToListAsync();
            List<ReservationAndItems> model = new();
            if (reservations == null)
            {
                return RedirectToAction("Reservations");
            }
            else
            {
                foreach (var obj in reservations)
                {
                    ReservationAndItems item = new ReservationAndItems();
                    item.Reservation = obj;
                    item.Items = await _context.ReservationItems.Where(x => x.ReservationItemId == obj.ReservationId).ToListAsync();
                    model.Add(item);
                }

                return View("Reservations", model);
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine("ManagerController FileExpired exception");
            TempData["error"] = "Request was unsuccesful, try again later.";
            return View("Error");

        }
    }

    public async Task<IActionResult> DeleteArchive()
    {
        try
        {
            List<Reservation> list = new();
            list = await _context.Reservations.Where(x => x.Archived).ToListAsync();

            _context.Reservations.RemoveRange(list);

            foreach (var obj in list)
            {
                var item = await _context.ReservationItems.FirstOrDefaultAsync(x => x.ReservationItemId == obj.ReservationId);
                _context.ReservationItems.Remove(item!);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Reservations");
        }
        catch(Exception ex)
        {
            Console.WriteLine("ManagerController DeleteArchive exception");
            TempData["error"] = "Request was unsuccesful, try again later.";
            return View("Error");
        }

    }

    [HttpPost]
    public async Task<IActionResult> DeleteSelected(List<string> list)
    {
        try
        {
            if (list != null)
            {
                List<Reservation> ReservationList = new();
                List<ReservationItem> ReservationItemsList = new();
                foreach (var obj in list)
                {
                    var Reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == obj);
                    ReservationList.Add(Reservation);

                    var ReservationItems = await _context.ReservationItems.Where(x => x.ReservationItemId == obj).ToListAsync();
                    //if reservation did not expire (if it did, Hosted Service hanldes the re-stocking), restocks de reserved items
                    if(Reservation.IsExpired == false)
                    foreach (var item in ReservationItemsList)
                    {
                        var product = await _context.Products.FindAsync(item.ProductId);
                        if(product != null)
                        product.Stock += item.Amount;
                    }

                    ReservationItemsList.AddRange(ReservationItems);
                }
                //finalizes removing items from db
                _context.Reservations.RemoveRange(ReservationList);
                _context.ReservationItems.RemoveRange(ReservationItemsList);
                await _context.SaveChangesAsync();

                return RedirectToAction("Reservations");

            }
            else
            {
                TempData["error"] = "No items selected";
                return RedirectToAction("Reservations");
            }
        }
        catch
        {
            Console.WriteLine("ManagerController DeleteSelected exception");
            TempData["error"] = "Request was unsuccesful, try again later.";
            return View("Error");
        }
    }


    [HttpPost]
    public async Task<IActionResult> MakeSale(List<string> IdList)
    {
        if (IdList != null)
        {
            List<Reservation> UpdateList = new();
            List<Sale> SaleList = new();

            foreach (var id in IdList)
            {
                var Reservation = await _context.Reservations.FindAsync(id);

                if (Reservation != null && Reservation.IsExpired == false)
                {
                    UpdateList.Add(Reservation);

                    Sale sale = new();

                    sale.ReservationId = "SAL" + Reservation.ReservationId.Substring(3);
                    sale.UserEmail = Reservation.UserEmail;
                    sale.Telephone = Reservation.Telephone;
                    sale.DNI = Reservation.DNI;
                    sale.BankTransferReceipt = Reservation.BankTransferReceipt;
                    sale.Created = Reservation.Created;
                    await _context.Sales.AddAsync(sale);
                }

            }
            _context.Reservations.RemoveRange(UpdateList);
            await _context.SaveChangesAsync();
            return new EmptyResult();
        }
        else
        {
            return StatusCode(400, "Custom Error Message 2"); // Bad Request

        }

    }
}





