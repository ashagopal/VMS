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
        private List<Vehicle> SetUpVehicleData()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            Vehicle vehicle = new Vehicle()
            {
                Id = 1,
                Make = "Toyota",
                Model = "Camry",
                AttributeValues = new List<AttributeValue>()
            { new AttributeValue(){  AttributeName="Door", Value="4"} },
                VehicleTypeId = 1

            };
            vehicles.Add(vehicle);
            vehicle = new Vehicle()
            {
                Id = 2,
                Make = "Fiat",
                Model = "Punto",
                AttributeValues = new List<AttributeValue>()
            { new AttributeValue(){  AttributeName="Door", Value="4"} },
                VehicleTypeId = 1
            };
            vehicles.Add(vehicle);
            return vehicles;
        }

        public Vehicle GetVehicle(int id)
        {
            List<Vehicle> vehicles = SetUpVehicleData();
            return (from v in vehicles where v.Id == id   select v).FirstOrDefault();
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
            List<Vehicle> vehicles = SetUpVehicleData();
            return (from v in vehicles where v.VehicleTypeId == typeOfVehicle.Id  select v).ToList();
        }

        public List<Data.Models.Attribute> GetAttributes(int vehicleTypeId)
        {
            return new List<Data.Models.Attribute>()
                {
               new Data.Models.Attribute (){
                    Id =1, Name="Door", UiName="Door", VehicleTypeId = 1
               },
               
               new Data.Models.Attribute (){
                    Id =2, Name="Wheels", UiName="Wheels", VehicleTypeId = 1
               }};

        }

        public bool UpdateVehicle(Vehicle modifiedVehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehicleType> GetVehicleTypes()
        {
            throw new NotImplementedException();
        }
    }
}
