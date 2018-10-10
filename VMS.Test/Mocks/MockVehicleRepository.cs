using System;
using System.Collections.Generic;
using System.Text;
using VMS.Data;
using VMS.Data.Models;
using VMS.ViewModels;
using System.Linq;

namespace VMS.Test.Mocks
{
    public class MockVehicleRepository: IVehicleRepository
    {

        public Vehicle GetVehicle(int id)
        {
            return new Vehicle()
            {
                Id = 1,
                Make = "Toyota",
                Model = "2011",
                AttributeValues = new List<AttributeValue>()
            { new AttributeValue(){  AttributeName="Door", Value="4"} }
            };
        }
        public bool AddVehicle(Vehicle newVehicle)
        {
            return true;
        }
        public bool RemoveVehicle(int id)
        {
            return true;
        }
        public List<Vehicle> GetAllVehicles(VehicleType typeOfVehicle)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            Vehicle vehicle = new Vehicle()
            {
                Id = 1,
                Make = "Toyota",
                Model = "Camry",
                AttributeValues = new List<AttributeValue>()
            { new AttributeValue(){  AttributeName="Door", Value="4"} }, VehicleTypeId = 1
               
            };
            vehicles.Add(vehicle);
            vehicle = new Vehicle()
            {
                Id = 1,
                Make = "Fiat",
                Model = "Punto",
                AttributeValues = new List<AttributeValue>()
            { new AttributeValue(){  AttributeName="Door", Value="4"} },
                VehicleTypeId = 1
            };
            vehicles.Add(vehicle);
            return (from v in vehicles where v.VehicleTypeId == typeOfVehicle.Id select v).ToList();
        }

        public List<Data.Models.Attribute> GetAttributes(int vehicleTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
