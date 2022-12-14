

using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Models
{
    public class CartItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity{ get; set; }
        public decimal Price { get; set; }

        public decimal Total 
        {
            get { return Quantity * Price; }
        }
        public string? Image { get; set; }

        public CartItem()
        {

        }

        public CartItem(Product prod)
        {
            ProductId = prod.ProductId!;
            ProductName = prod.Category + " " + prod.Brand + " " + prod.Model;
            Price = (decimal)prod.Price;
            Quantity = 1;
            Image = prod.MainImage;

        }
    }
}
