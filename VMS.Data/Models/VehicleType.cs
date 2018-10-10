using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Data.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<Models.Attribute> Attributes { get; set; }
    }
}
