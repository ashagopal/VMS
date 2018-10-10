namespace VMS.Helpers
{
    public static class ModelMapper
    {
        public static ViewModels.VehicleViewModel ToVehicleViewModel(this VMS.Data.Models.Vehicle vehicle)
        {
            var viewModel = new ViewModels.VehicleViewModel();
            viewModel.Id = vehicle.Id;
            //viewModel.VehicleType = vehicle.VehicleType.Name;
            viewModel.VehicleTypeId = vehicle.VehicleTypeId;
            viewModel.Make = vehicle.Make;
            viewModel.Model = vehicle.Model;
            vehicle.AttributeValues.ForEach(q =>
            {
                viewModel.Attributes.Add(new System.Collections.Generic.KeyValuePair<string, string>(q.AttributeName, q.Value));
            });

            return viewModel;
        }

        public static VMS.Data.Models.Vehicle ToVehicleModel(this ViewModels.VehicleViewModel vehicle)
        {
            var model = new Data.Models.Vehicle();
            model.Id = vehicle.Id;
            model.VehicleTypeId = vehicle.VehicleTypeId ;
            model.Make = vehicle.Make;
            model.Model = vehicle.Model;
            model.AttributeValues = new System.Collections.Generic.List<Data.Models.AttributeValue>();
            vehicle.Attributes.ForEach(q =>
            {
                model.AttributeValues.Add(new Data.Models.AttributeValue() { AttributeId = int.Parse(q.Key), Value = q.Value, VehicleId = vehicle.Id  });
            });

            return model;
        }

        //        public  string ConvertToJSON(object obj)
        //        {

        //            return JsonConvert.SerializeObject(obj);


        //        }

        //        public List<VehicleType> GetVehicleTypes()
        //        {
        //            List<VehicleType> vehicleType = new List<VehicleType>()
        //            {
        //                new VehicleType(){
        //                    Id = 1, Name="Car"
        //                }
        //            };

        //            return vehicleType;

        //        }

        //        public List<Model.Attribute> GetAttributes(int vehicleTypeId)
        //        {
        //            List<Model.Attribute> attribute = new List<Model.Attribute>()
        //            {
        //                new Model.Attribute(){
        //                            Id = 1,VehicleType=1, Name="NumDoors", UiName="Number of doors", Value="4"
        //                       },

        //               new Model.Attribute(){
        //                           Id = 2,VehicleType=1, Name="Wheels", UiName="Number of wheels", Value="4"
        //                       }
        //            };
        //            return attribute;
        //        }
        //        public List<VehicleViewModel> GetVehicles()
        //        {
        //            List<VehicleViewModel> vehicle = new List<VehicleViewModel>()
        //            {
        //                new VehicleViewModel(){
        //                    Id = 1, Name="Toyota", Make="Camry", Model = "2001", VehicleTypeId= 1,
        //                    Attributes= new List<Model.Attribute>(){
        //                       new Model.Attribute(){
        //                            Id = 1, VehicleType=1, Name="NumDoors", UiName="Number of doors", Value="4"
        //                       },
        //                       new Model.Attribute(){
        //                           Id = 2, VehicleType=1, Name="Wheels", UiName="Number of wheels", Value="4"
        //                       }

        //                    }
        //                },
        //                new VehicleViewModel(){
        //                    Id = 2, Name="Toyota", Make="Corolla", Model = "2011", VehicleTypeId= 1,
        //                    Attributes= new List<Model.Attribute>(){
        //                       new Model.Attribute(){
        //                            Id = 1,VehicleType=1, Name="NumDoors", UiName="Number of doors", Value="4"
        //                       },
        //                       new Model.Attribute(){
        //                           Id = 2,VehicleType=1, Name="Wheels", UiName="Number of wheels", Value="4"
        //                       }

        //                    }
        //                }
        //            };

        //            return vehicle;

        //        }


    }
}
