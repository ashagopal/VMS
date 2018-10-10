using Microsoft.EntityFrameworkCore;
using VMS.Data.Models;
using Attribute = VMS.Data.Models.Attribute;

namespace VMS.Data.DatabaseAccess
{
    public class VMSContext : DbContext
    {
        public VMSContext(DbContextOptions<VMSContext> options) : base(options)
        {
        }

        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<AttributeValue> AttributeValue { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }

        //Seeding master data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VMS.Data.Models.VehicleType>(t =>
                t.HasData(new VehicleType() { Id = 1, Name = "Car" })
            );

            modelBuilder.Entity<VMS.Data.Models.Attribute>(q => q.HasData(
                  new Attribute() { Id = 1, Name = "Doors", UiName = "Doors", VehicleTypeId = 1 },
                  new Attribute() { Id = 2, Name = "Engine", UiName = "Engine", VehicleTypeId = 1 },
                  new Attribute() { Id = 3, Name = "BodyType", UiName = "Body Type", VehicleTypeId = 1 },
                  new Attribute() { Id = 4, Name = "Wheel", UiName = "Wheels", VehicleTypeId = 1 }
                 ));
        }
    }
}
