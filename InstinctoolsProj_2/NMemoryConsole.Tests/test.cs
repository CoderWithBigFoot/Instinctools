using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMemoryConsole.Contexts;
using NMemoryConsole.Entities;
using System.Linq;

namespace NMemoryConsole.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private void MyTestInitialize() {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            EffortProviderFactory.ResetDb();
        }

        private void PrepareData() {
            using (var context = new ProductContext()) {
                Product test_1 = new Product { Name = "First", Price = "123" };
                Product test_2 = new Product { Name = "Second", Price = "123" };

                context.Products.Add(test_1);
                context.Products.Add(test_2);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Update_UpdateObject_EntityStateIsModified() {
            MyTestInitialize();
            PrepareData();
            using (ProductContext context = new ProductContext())
            {
                var result = context.Products.FirstOrDefault(x => x.Name == "First");

                context.Entry<Product>(result).State = System.Data.Entity.EntityState.Modified;
                result.Name = "Changed";
                context.SaveChanges();

                var endResult = context.Products.FirstOrDefault(x => x.Name == "Changed");

                Assert.AreEqual(endResult.Name, "Changed");
            }

            
        }

    }
}
