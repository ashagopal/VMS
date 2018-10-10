using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Data.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VehicleTypeId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [NotMapped]
        public List<AttributeValue> AttributeValues { get; set; }

        [NotMapped]
        public VehicleType VehicleType { get; set; }
    }
}
