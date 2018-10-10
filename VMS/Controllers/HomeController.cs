using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VMS.Data;
using VMS.Data.Models;
using VMS.Helpers;
using VMS.ViewModels;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IVehicleRepository respository;

        public HomeController(IVehicleRepository respository)
        {
            this.respository = respository;
        }

       [HttpGet("{vehicleTypeId}")]
        public HomeViewModel Get(int vehicleTypeId)
        {
           
            var vehicles = respository.GetAllVehicles(new Data.Models.VehicleType() { Id = vehicleTypeId });
            return new HomeViewModel()
            {

                Vehicles = vehicles != null && vehicles.Any() ? vehicles.Select(q => q.ToVehicleViewModel()).ToList() : new List<VehicleViewModel>(),
                VehicleAttributes = this.respository.GetAttributes(vehicleTypeId),
                VehicleType = this.respository.GetVehicleTypes()
            };
        }
    }
}
