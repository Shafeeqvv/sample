using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Model
{
    public class Rates
    {
        [Key]
        public int RateId { get; set; }
        [ForeignKey("ParkingLots")]
        public int LotId { get; set; }
        public virtual ParkingLots ParkingLots { get; set; } = null!;
        public int RateType { get; set; }
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public float Price { get; set; }
        public string Currency { get; set; } = null!;
        public string ApplicableDays { get; set; } = null!;
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public string Active { get; set; } = null!;
    }
}
