using Ninject.Modules;
using BookStore.Business.Services;
using BookStore.Data.Contexts;

namespace BookStore.Business.Infrastructure.NinjectModules
{
    public class ServiceBindingModule : NinjectModule
    {
        protected string _connectionString;

        public ServiceBindingModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IAuthorService>().To<AuthorService>().WithConstructorArgument("context", new BookStoreContext(_connectionString));
            Bind<IBookService>().To<BookService>().WithConstructorArgument("context", new BookStoreContext(_connectionString));
        }
    }
}
