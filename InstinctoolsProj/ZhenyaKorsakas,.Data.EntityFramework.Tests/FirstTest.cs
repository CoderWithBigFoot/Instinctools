using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForUnitTesting.Interaction;
using System.Collections.Generic;
using ForUnitTesting.Entities;
namespace ZhenyaKorsakas_.Data.EntityFramework.Tests
{
    [TestClass]
    public class FirstTest
    {
        private CarInteraction interaction;

        public FirstTest() {
            this.interaction = new CarInteraction();
        }

        /*[TestMethod]
        public void CheckEquality()
        {
            Car car = null;
            Car anotherCar = null;

            car = interaction.CreateCar(1, "name");
            anotherCar = car;

            Assert.AreEqual(1, car.Id);
            Assert.AreEqual("name", car.Name);
            
        }*/

        [TestMethod]
        public void CheckValues() {
            Car car = new Car() { Id = 1,Name = "Zheka"};
            PrivateObject pObject = new PrivateObject(car);

            Assert.AreEqual(pObject.GetFieldOrProperty("Creator"),"the firstcreator");
        }
        

    }
    
}
