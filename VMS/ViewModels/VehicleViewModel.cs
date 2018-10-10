using System.Collections.Generic;

namespace VMS.ViewModels
{
    public class VehicleViewModel
    {
        public VehicleViewModel()
        {
            Attributes = new List<KeyValuePair<string, string>>();
        }

        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public List<KeyValuePair<string,string>> Attributes { get; set; }
    }
}
