using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhenyaKorsakas.Data.Entities;
using ZhenyaKorsakas.Data.Models;

namespace ZhenyaKorsakas.Services.Interfaces
{
   public interface IHumanService
    {
        IEnumerable<string> GetFullNames(Func<Human, bool> predicate);
    }
}
