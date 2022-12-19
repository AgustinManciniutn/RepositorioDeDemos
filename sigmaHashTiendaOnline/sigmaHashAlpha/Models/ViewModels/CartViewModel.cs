using System.ComponentModel.DataAnnotations;

namespace sigmaHashAlpha.Models.ViewModels
{
    public class CartViewModel
    {
        public string? UserEmail {get;set;}

        public List<CartItem> CartItems { get; set; }
 
        public decimal GrandTotal { get; set; }


    }
}
