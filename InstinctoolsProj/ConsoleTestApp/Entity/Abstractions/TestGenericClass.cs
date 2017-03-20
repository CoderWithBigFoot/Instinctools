using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleTestApp.Entity.Contexts;
using ConsoleTestApp.Entity.Entities;
namespace ConsoleTestApp
{

    public class TestGenericClass<T, C> where T : class where C : DbContext,new() 
    {
        private C context = new C();
        public C Context {
            get { return this.context; }
            set { this.context = value; }
        }

        public virtual IQueryable<T> GetAll() {
            return Context.Set<T>();
        }

        public virtual IQueryable<T> FindBy(Func<T, bool> predicate) {
            return Context.Set<T>().Where(x=>predicate(x));
        }

    }
}
