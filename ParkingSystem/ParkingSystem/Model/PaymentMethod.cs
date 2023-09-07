using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Model
{
    public class PaymentMethod
    {
        [Key]
        public int PaId { get; set; }
        public string PaymentType { get; set; } = null!;
        public string Active { get; set; }=null!;
    }
}
