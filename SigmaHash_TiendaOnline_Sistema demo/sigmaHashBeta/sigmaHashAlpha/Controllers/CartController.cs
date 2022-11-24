using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure;
using sigmaHashAlpha.Infrastructure.Email;
using sigmaHashAlpha.Infrastructure.Email.MailjetTemplate;
using sigmaHashAlpha.Infrastructure.HosttedService;
using sigmaHashAlpha.Infrastructure.Reservations;
using sigmaHashAlpha.Infrastructure.StockHostedService;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using sigmaHashAlpha.Models.ViewModels;
using System.Collections.Generic;

namespace sigmaHashAlpha.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext db;
        private IDgenerator<Reservation> idgen = new IDgenerator<Reservation>();
        private readonly EmailHostedService emailsender;
        private readonly StockHostedService StockService;

        public CartController(ApplicationDbContext _db, EmailHostedService emailsender, StockHostedService _StockService)
        {
            db = _db;
            this.emailsender = emailsender;
            StockService = _StockService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                string email = string.Empty;
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    email = HttpContext.User.Identity.Name.ToString();
                }

                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

                CartViewModel cartVM = new()
                {
                    CartItems = cart,
                    GrandTotal = cart.Sum(x => x.Quantity * x.Price),
                    UserEmail = email
                };

                return View("Index", cartVM);
            }
            catch
            {
                return View("Error");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(string id)
        {
            try
            {
                ProductList product = await db.Products.FindAsync(id);
                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
                CartItem cartItem = cart.Where(p => p.ProductId == id).FirstOrDefault();

                if (cartItem == null)
                {
                    cart.Add(new CartItem(product!));
                }
                else
                {
                    cartItem.Quantity += 1;
                }
                HttpContext.Session.SetJson("Cart", cart);
                TempData["success"] = "The item has been added";
                //return PartialView("_Notification");

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch
            {
                TempData["error"] = "Could not add the item, please try again";

                return RedirectToAction("Store","Products");
            }

        }

        [HttpPost]
        public IActionResult Decrease(string id)
        {
            try
            {
                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
                CartItem cartItem = cart.Where(p => p.ProductId == id).FirstOrDefault();

                if (cartItem.Quantity > 1)
                {
                    --cartItem.Quantity;
                }
                else
                {
                    cart.RemoveAll(p => p.ProductId == id);
                }
                HttpContext.Session.SetJson("Cart", cart);


                TempData["success"] = "The item has been removed";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Could not remove the item, please try again";

                return RedirectToAction("Index");
            }

        }
        public async Task<IActionResult> Increase(string id)
        {
            try
            {
                ProductList product = await db.Products.FindAsync(id);
                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
                CartItem cartItem = cart.Where(p => p.ProductId == id).FirstOrDefault();



                cartItem.Quantity += 1;

                HttpContext.Session.SetJson("Cart", cart);
                TempData["success"] = "The item has been added";
                //return PartialView("_Notification");

                return Redirect(Request.Headers["Referer"].ToString());

            }
            catch
            {
                TempData["error"] = "Could not add an item, please try again";
                return Redirect(Request.Headers["Referer"].ToString());
            }

        }

        public IActionResult RemoveItem(string id)
        {
            try
            {
                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
                CartItem cartItem = cart.Where(p => p.ProductId == id).FirstOrDefault();

                cart.RemoveAll(p => p.ProductId == id);

                HttpContext.Session.SetJson("Cart", cart);


                TempData["success"] = "The item has been removed";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Could not remove the item";

                return RedirectToAction("Index");
            }


        }



        public async Task<IActionResult> SubmitReservation()
        {
            try
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var email = HttpContext.User.Identity.Name;
                    Reservation Reserv = new();
                    Reservation check = new();

                    do
                    {
                        var newid = new string(idgen.IDGenerator(Reserv));
                        check = await db.Reservations.FindAsync(newid);
                        Reserv.ReservationId = newid;
                    }while(check != null);

                    List<CartItem> usercart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

                    foreach (var obj in usercart)
                    {
                        var item = new ReservationItem();
                        item.ReservationItemId = Reserv.ReservationId;
                        //item.Reservation = Reserv;
                        item.ProductId = obj.ProductId;
                        item.Amount = obj.Quantity;
                        item.Price = obj.Price;
                        item.ProductName = obj.ProductName;
                        await db.ReservationItems.AddAsync(item);

                        var prod = await db.Products.FindAsync(obj.ProductId);
                        prod!.Stock -= obj.Quantity;

                    }
                    
                    Reserv.UserEmail = email!;
                    await db.Reservations.AddAsync(Reserv);
                    var UserReservation = new User_Reservation();
                    UserReservation.ReservationId = Reserv.ReservationId;
                    var user  = await db.Users.Where(m => m.Email == email).FirstOrDefaultAsync();
                    UserReservation.Id = user.Id;
                    await db.UserReservations.AddAsync(UserReservation);

                    await StockService.MakeReservation(Reserv.ReservationId); //add Reservation ID to Buffer Block of hosted service

                    await db.SaveChangesAsync();

                    usercart = new List<CartItem>();

                    HttpContext.Session.SetJson("Cart", usercart);
                    MailjetTemplate template = new MailjetTemplate();
                    await emailsender.SendEmailAsync(new EmailModel
                    {
                        EmailAddress = email!,
                        Subject = "Reserva exitosa!",
                        TemplateId = template.TemplateTransferencia
                    });

                    return View("Thanks");


                }
                else
                {
                    TempData["error"] = "Request was unsuccesful, try again later.";
                    return RedirectToAction("Index", "Cart");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cart/SubmitReservation exception");
                TempData["error"] = "Request was unsuccesful, try again later.";
                return RedirectToAction("Index", "Cart");
            }
        }
    }
}
