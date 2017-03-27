using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IHuman
    {
        string Name { set; get; }
    }

    public abstract class HumanBase : IHuman
    {
        public virtual string Name { set; get; }
    }

    public class Human : HumanBase
    {
        public string Sername { set; get; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            

            Console.ReadKey();
        }
    }
}
