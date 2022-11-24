using Microsoft.AspNetCore.Mvc;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.ViewModels;

namespace sigmaHashAlpha.Infrastructure
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel smallcartVM;

            if(cart == null || cart.Count == 0)
            {
                smallcartVM = null;
            }
            else
            {
                smallcartVM = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price)
                };
            }
            return View(smallcartVM);

        }
    }
}
