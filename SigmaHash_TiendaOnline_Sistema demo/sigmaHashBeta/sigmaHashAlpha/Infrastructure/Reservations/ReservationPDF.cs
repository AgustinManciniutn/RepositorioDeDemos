using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Infrastructure.Reservations
{
    public class ReservationPDF
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string ReservationId { get; set; }
        public string FileName { get; set; }

    }
}
