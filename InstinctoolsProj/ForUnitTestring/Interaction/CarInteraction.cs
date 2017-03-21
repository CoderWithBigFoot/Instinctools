using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForUnitTesting.Entities;
using System.Threading;
namespace ForUnitTesting.Interaction
{
    public class CarInteraction {
        public Car CreateCar(int id, string name) {
            Thread.Sleep(3000);
            return new Car { Id = id, Name = name };
        }
    }
    
}
