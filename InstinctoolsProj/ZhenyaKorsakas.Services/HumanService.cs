using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhenyaKorsakas.Services.Interfaces;
using ZhenyaKorsakas.Services.Abstractions;
using ZhenyaKorsakas.Data.Models;
using ZhenyaKorsakas.Data;

namespace ZhenyaKorsakas.Services
{
    public class HumanService: EntityService<Human>, IHumanService {

        public HumanService(IUnitOfWork uow, IGenericRepository<Human> humanRepo) : base(uow, humanRepo) { }

        public IEnumerable<string> GetFullNames(Func<Human,bool> predicate) {

            foreach (var current in Find(predicate)) {
                yield return $"{current.Name} {current.Surname}";
            }
        }

    }
}
