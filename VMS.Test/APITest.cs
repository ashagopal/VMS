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
    public class APITest
    {
        
        HomeController homeController;

        public APITest()
        {

        }
        

        [SetUp]
        public void TestSetup()
        {
           

            

        }



        [TestCase(1)]
        public void GetAllVehicles_ValidInput(int id)
        {
            // Arrange
            MockVehicleRepository repository = new MockVehicleRepository();
            var controller = new HomeController(repository);
           

            // Act
            var response = controller.Get(id);

            // Assert   
            Assert.IsTrue(response.Vehicles.Count>0,"The List is empty");

        }
        [TestCase(0)]
        public void GetAllVehicles_InvalidInput(int id)
        {
            // Arrange
            MockVehicleRepository repository = new MockVehicleRepository();
            var controller = new HomeController(repository);


            // Act
            var response = controller.Get(id);

            // Assert   
            Assert.IsTrue(response.Vehicles.Count == 0, "The List is not empty");

        }


    }

}