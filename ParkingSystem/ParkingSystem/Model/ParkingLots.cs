using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Model
{
    public class ParkingLots
    {
        [Key]
        public int LotId { get; set; }
        public string Lotname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Capacity { get; set; }
        public string OperatingHours { get; set; } = null!;
        public string PaymentMethodsAccepted { get; set; } = null!;
        public float Latitude { get; set; } 
        public float Longitude { get; set; }
        public string Description { get; set; } = null!;
        public string ManagementContactInformation { get; set; } = null!;
        public string Active { get; set; } = null!;
    }
}
