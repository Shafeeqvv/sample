using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystem.Model
{
    public class ParkingSpace
    {
        [Key]
        public int SpaceId { get; set; }
        [ForeignKey("ParkingLots")]
        public int LotId { get; set; }
        public virtual ParkingLots? ParkingLots { get; set; } 
        public string SpaceNumber { get; set; } = null!;
        public int SpaceType { get; set; }
        public int Status { get; set; }
        public DateTime? EntryTimestamp { get; set; }
        public DateTime? ExitTimestamp { get; set; }
        public string VehicleDetails { get; set; } = null!;
        public int SensorId { get; set; }
        public string Coordinates { get; set; } = null!;
        public string Active { get; set; } = null!;
    }
}
