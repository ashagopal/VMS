using System;
using System.Collections.Generic;
using System.Text;
using VMS.Data.Models;

namespace VMS.Data
{
    public interface IVehicleRepository
    {
        Vehicle GetVehicle(int id);
        bool AddVehicle(Vehicle newVehicle);
        bool RemoveVehicle(int id);
        List<Vehicle> GetAllVehicles(VehicleType typeOfVehicle);
        List<Models.Attribute> GetAttributes(int vehicleTypeId);
        bool UpdateVehicle(Vehicle modifiedVehicle);
        List<VehicleType> GetVehicleTypes();
    }
}
