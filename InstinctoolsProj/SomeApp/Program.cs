using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhenyaKorsakas.Data.EntityFramework.Repositories;
using ZhenyaKorsakas.Data.EntityFramework.Contexts;
using ZhenyaKorsakas.Data.EntityFramework.Entities;
namespace SomeApp
{
   public class Program
    {
       public static void Main(string[] args)
        {
            using (UnitOfWork uow = new UnitOfWork()) {
                uow.TestEntities.Add(new TestEntity { Id = 1 ,Name = "Zheka"});
                uow.Save();
            }


                Console.ReadKey();
        }
    }
}
