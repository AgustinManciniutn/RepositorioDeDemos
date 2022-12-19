using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Infrastructure.Reservations;

public class ReservationItem
{


    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string ReservationItemId    { get; set; }

    public string ProductId        { get; set; }
    public string ProductName { get; set; }
    public int    Amount           { get; set; }
    public decimal Price            { get; set; }
    public decimal Total { get { return Amount * Price; } }
    

    public ReservationItem(string reservationItemId, string productId, string productName, int amount, decimal price)
    {
        ReservationItemId = reservationItemId;
        ProductId = productId;
        ProductName = productName;
        Amount = amount;
        Price = price;
    }
}
