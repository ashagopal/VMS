using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VMS.Data.DatabaseAccess;
using VMS.Data.Models;

namespace VMS.Data.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VMSContext dbContext;

        public VehicleRepository(VMSContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddVehicle(Vehicle newVehicle)
        {
            dbContext.Vehicle.Add(newVehicle);
            dbContext.SaveChanges();

            var attributeValues = newVehicle.AttributeValues.Select(q => {
                q.VehicleId = newVehicle.Id;
                return q; });


            dbContext.AttributeValue.AddRange(attributeValues);
            dbContext.SaveChanges();
            return true;
        }

        public List<Vehicle> GetAllVehicles(VehicleType typeOfVehicle)
        {
            var vehicles = dbContext.Vehicle.Where(q => q.VehicleTypeId == typeOfVehicle.Id).ToList();
            vehicles.ForEach(q =>
            {
                q.AttributeValues = dbContext.AttributeValue.Where(attr => attr.VehicleId == q.Id).ToList()
                                                           .Select(r =>
                                                            {
                                                                r.AttributeName = dbContext.Attribute.FirstOrDefault(s => s.Id == r.AttributeId).Name;
                                                                return r;
                                                            }).ToList();
            });

            return vehicles;
        }

        public Vehicle GetVehicle(int id)
        {
            var vehicle = dbContext.Vehicle.FirstOrDefault(q => q.Id == id);
            vehicle.AttributeValues = dbContext.AttributeValue.Where(attr => attr.VehicleId == vehicle.Id).ToList().Select(r =>
            {
                r.AttributeName = dbContext.Attribute.FirstOrDefault(s => s.Id == r.AttributeId).Name;
                return r;
            }).ToList();



            return vehicle;
        }

        public bool RemoveVehicle(int id)
        {
            var existingVehicle = GetVehicle(id);
            if (existingVehicle != null)
            {
                dbContext.RemoveRange(existingVehicle.AttributeValues);
                dbContext.Vehicle.Remove(existingVehicle);

                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public List<VehicleType> GetVehicleTypes()
        {
            var types= dbContext.VehicleType.ToList();
            types.ForEach(q =>
            {
                q.Attributes = dbContext.Attribute.Where(a => a.VehicleTypeId == q.Id).ToList();
            });
            return types; 
        }

        public List<Attribute> GetAttributes(int vehicleTypeId)
        {
            var types = dbContext.Attribute.Where(q => q.VehicleTypeId == vehicleTypeId).ToList();
            return types;
        }
    }
}
