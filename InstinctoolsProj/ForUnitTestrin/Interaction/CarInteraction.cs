using System;
using System.Collections.Generic;
using System.Text;
using ForUnitTesting.Entities;
namespace ForUnitTesting.Interaction
{
    public class CarInteraction {

        public Car CreateNewCar(int id,string name) {
            return new Car { Id = id, Name = name };
        }
    }
    
    
}
