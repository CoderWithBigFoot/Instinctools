using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZhenyaKorsakas.ConsoleTesting;
namespace ZhekaKorsakas.Data.EntityFramework.Tests
{
    public interface ITest {
        string Name { set; get; }

        int GetValue();
    }

    [TestClass]
   public class ConsoleTestringTests
    {
        [TestMethod]
        public void addToCollection_AddCarToCollection_Added() {

            ITest test = Mock.Of<ITest>(
                x=>x.Name == "Some name" &&
                x.GetValue() == 1
                );
            


            CarsInteraction interaction = new CarsInteraction();
            Car car = new Car() { Name = "Audi" };
            List<Car> carCollection = new List<Car>();

            Mock<CarValidation> validation = new Mock<CarValidation>();
            validation.Setup(x => x.Check(It.IsAny<Car>())).Returns(true);


            interaction.AddToCollection(carCollection, car, validation.Object);
            CollectionAssert.Contains(carCollection, car);
        }

    }
}
