using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhenyaKorsakas.ConsoleTesting
{
   public class CarsInteraction
    {
        public void AddToCollection(ICollection<Car> cars, Car car,CarValidation validation) {
            if (validation.Check(car)) { cars.Add(car); }
        }
    }
}
