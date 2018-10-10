using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VMS.Data;
using VMS.Data.Models;
using VMS.Helpers;
using VMS.ViewModels;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository respository;

        public VehicleController(IVehicleRepository respository)
        {
            this.respository = respository;
        }

        [HttpGet("{vehicleTypeId}/{Id}")]
        public VehicleViewModel Get(int vehicleTypeId, int id)
        {
            var vehicle = respository.GetVehicle(id);
            List<KeyValuePair<string, string>> attributeValues = new List<KeyValuePair<string, string>>();
            foreach (AttributeValue attribute in vehicle.AttributeValues)
            {
                attributeValues.Add(new KeyValuePair<string, string>(attribute.AttributeName, attribute.Value));
            }

            return new VehicleViewModel()
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Attributes = attributeValues

            };
        }

        [HttpGet("add-vehicle/{vehicleTypeId}", Name = "Get")]
        public AddVehicleViewModel GetAddVehicleAttrbutes(int vehicleTypeId)
        {
            return new AddVehicleViewModel()
            {
                Vehicle = new VehicleViewModel(),
                Attributes = this.respository.GetAttributes(vehicleTypeId)

            };
        }

        [HttpPost("add-vehicle")]
        public void Post([FromBody] VehicleViewModel value)
        {
            this.respository.AddVehicle(value.ToVehicleModel());
        }
    }
}
