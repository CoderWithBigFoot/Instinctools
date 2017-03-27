using System;
using System.Collections.Generic;
using ZhenyaKorsakas.Data.Models;
using ZhenyaKorsakas.Data;
using ZhenyaKorsakas.BLL.Abstractions;
using ZhenyaKorsakas.BLL.Interfaces;

namespace ZhenyaKorsakas.Services
{
    public class HumanService: EntityService<Human>, IHumanService {

        public HumanService(IUnitOfWork uow, IRepository<Human> humanRepo) : base(uow, humanRepo) { }

        public IEnumerable<string> GetFullNames(Func<Human,bool> predicate) {

            foreach (var current in Find(predicate)) {
                yield return $"{current.Name} {current.Surname}";
            }
        }
    }
}
