using System;
using Ninject.Modules;
using BookStore.Business.Services;
using BookStore.Business;

namespace BookStore.Business.Services.Infrastructure.NinjectModules
{
    public class ServiceBindingModule : NinjectModule
    {
        protected string _connectionString;

        private ServiceBindingModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IAuthorService>().To<AuthorService>().WithConstructorArgument("connectionString", _connectionString);
            Bind<IBookService>().To<BookService>().WithConstructorArgument("connectionString", _connectionString);
        }
    }
}
