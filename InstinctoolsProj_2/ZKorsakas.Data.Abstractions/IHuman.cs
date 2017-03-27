using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKorsakas.Data.EntityFramework.Abstractions
{
    public interface IHuman
    {
        string Name { set; get; }
        string Surname { set; get; }
    }
}
