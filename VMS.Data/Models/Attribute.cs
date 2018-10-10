using System;
using System.Collections.Generic;
using System.Text;

namespace VMS.Data.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string Name { get; set; }
        public string UiName { get; set; }
    }
}
