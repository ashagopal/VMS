using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Data.Models
{
    public class AttributeValue
    {
        public int Id { get; set; }
       public int AttributeId { get; set; }
        public int VehicleId { get; set; }
        public string Value { get; set; }

        [NotMapped]
        public string AttributeName { get; set; }
    }
}
