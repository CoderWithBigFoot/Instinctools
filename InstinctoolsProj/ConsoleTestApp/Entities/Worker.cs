using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ConsoleTestApp.Entities
{
   public class Worker
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Sername { set; get; }

        public override string ToString()
        {
            return $"Id:{Id} Name: {Name} Sername: {Sername}";
        }
    }
}
