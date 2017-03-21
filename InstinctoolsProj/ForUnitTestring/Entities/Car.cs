using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForUnitTesting.Entities
{
    public class Car {
        public int Id { set; get; }
        public string Name { set; get; }

        private string Creator { set; get; } = "the first creator";
    }
    
    
}
