using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Usertype { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime lastLoginDate { get; set;}
        public int AccountStatus { get; set;}
        public string Active { get; set; } = null!;
    }
}
