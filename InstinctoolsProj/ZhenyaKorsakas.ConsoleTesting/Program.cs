using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZhenyaKorsakas.Data.EntityFramework.Repositories;

namespace ZhenyaKorsakas.ConsoleTesting
{
   public class Program
    {
       public static void Main(string[] args)
        {
            using (UnitOfWork uow = new UnitOfWork("name=Instinctools.Connection_1")) {

                foreach (var current in uow.TestEntities.GetAll()) {
                    Console.WriteLine(current.ToString());
                }

            }

                Console.ReadKey();
        }
    }
}
