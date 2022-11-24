using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Infrastructure.Reservations
{
    public class Reservation
    {
        [Key]
        [MaxLength(50)]
        public string ReservationId { get; set; }

        [MaxLength(200)]
        public string UserEmail { get; set; }
       
        [MaxLength(50)]
        public string? Telephone { get; set; }
        [MaxLength(50)]
        public string? DNI { get; set; }

        public byte[]? BankTransferReceipt { get; set; }

        [MaxLength(80)]
        public string Created { get; set; } = DateTime.Now.ToString();

        public bool IsExpired { get; set; } = false;

        public bool Archived { get; set; } = false;

        //public ICollection<ReservationItem> Items { get; set; }
    }
}
