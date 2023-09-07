using Microsoft.EntityFrameworkCore;
using System;

namespace ParkingSystem.Model
{
    public class ParkingContext:DbContext
    {
        public ParkingContext()
        {

        }
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ParkingLots> ParkingLots { get; set; } = null!;
        public virtual DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;
        public virtual DbSet<ParkingTransactions> ParkingTransactions { get; set; } = null!;
        public virtual DbSet<Rates> Rates { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
    }
}
