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
    public class HomeAPITest
    {

        HomeController homeController;


        public HomeAPITest()
        {

        }
        

        [SetUp]
        public void TestSetup()
        {

            // Arrange
            MockVehicleRepository repository = new MockVehicleRepository();
            homeController = new HomeController(repository);
        }
               
        [TestCase(1)]
        public void GetAllVehicles_ValidInput(int id)
        {
                      

            // Act
            var response = homeController.Get(id);

            // Assert   
            Assert.IsTrue(response.Vehicles.Count>0,"The Vehicle list is empty");

        }
        [TestCase(0)]
        public void GetAllVehicles_InvalidInput(int id)
        {
            


            // Act
            var response = homeController.Get(id);

            // Assert   
            Assert.IsTrue(response.Vehicles.Count == 0, "The List is not empty");

        }

    }

}