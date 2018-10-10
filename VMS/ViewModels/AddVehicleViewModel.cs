using System.Collections.Generic;

namespace VMS.ViewModels
{
    public class AddVehicleViewModel
    {
        public VehicleViewModel Vehicle { get; set; }
        public List<VMS.Data.Models.Attribute> Attributes { get; set; }
    }
}