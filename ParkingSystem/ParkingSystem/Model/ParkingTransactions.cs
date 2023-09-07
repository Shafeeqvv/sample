using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Model
{
    public class ParkingTransactions
    {
        [Key]
        public int TransactionId { get; set; }
        [ForeignKey("ParkingSpace")]
        public int SpaceId { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; } = null!;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public DateTime EntryTimestamp { get; set; }
        public DateTime ExitTimestamp { get; set; }
        public float Duration { get; set; }
        public string VehicleDetails { get; set; } = null!;
        [ForeignKey("PaymentMethod")]
        public int PaymentMtd { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public float PaymentAmount { get; set; }
        public float DiscountApplied { get; set; }
        public int TransactionStatus { get; set; }
        public string Active { get; set; } = null!;
    }
}
