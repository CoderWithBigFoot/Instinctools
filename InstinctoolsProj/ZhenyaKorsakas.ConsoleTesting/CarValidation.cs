using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhenyaKorsakas.ConsoleTesting
{
   public class CarValidation
    {
        public virtual bool Check(Car car) {
            return String.IsNullOrEmpty(car.Name);
        }
    }
}
