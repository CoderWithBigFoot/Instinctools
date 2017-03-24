using System;
using System.Collections.Generic;
using ZhenyaKorsakas.Data.Models;

namespace ZhenyaKorsakas.BLL.Interfaces
{
    public interface IHumanService
    {
        IEnumerable<string> GetFullNames(Func<Human, bool> predicate);
    }
}
