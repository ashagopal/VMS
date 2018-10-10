using NUnit.Framework;
using System.Collections.Generic;
using VMS.Controllers;
using VMS.Data;
using VMS.Data.Models;
using VMS.Test.Mocks;
using VMS.ViewModels;

namespace UnitTest
{
    [TestFixture]
    public class VehicleAPITest
    {

        VehicleController vehicleController;


        public VehicleAPITest()
        {

        }


        [SetUp]
        public void TestSetup()
        {

            // Arrange
            MockVehicleRepository repository = new MockVehicleRepository();
            vehicleController = new VehicleController(repository);
        }

        [TestCase(1,1)]
        public void GetVehicle_ValidInput(int typeId,int id)
        {


            // Act
            var response = vehicleController.Get(typeId, id); ;

            // Assert   
            Assert.IsTrue(response.Id==id, "Vehicle not present");

        }
        [TestCase(0,0)]
        public void GetAllVehicles_InvalidInput(int typeId, int id)
        {                       
            // Act
            var response = vehicleController.Get(typeId, id);

            // Assert   
            Assert.IsNull(response, "Vehicle present");

        }

    }

}