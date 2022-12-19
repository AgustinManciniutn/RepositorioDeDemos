using sigmaHashAlpha.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Infrastructure.Reservations
{
    public class User_Reservation
    {
        public User_Reservation(string id, string reservationId)
        {
            Id = id;
            ReservationId = reservationId;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserReservationId { get; set; }

        public string Id { get; set; }

        public string ReservationId { get; set; }

    }
}
