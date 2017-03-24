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

        private IUnitOfWork uow;
        private IGenericRepository<Human> humanRepository;

        public HumanService(IUnitOfWork uow, IGenericRepository<Human> humanRepo): base(uow,humanRepo) {

        }


    }
}
