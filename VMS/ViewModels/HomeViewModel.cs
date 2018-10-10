using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.ViewModels
{
    public class HomeViewModel
    {
        public List<VehicleViewModel> Vehicles { get; set; }
        public dynamic VehicleType { get; set; }
        public List<VMS.Data.Models.Attribute> VehicleAttributes { get; set; }
    }
}
