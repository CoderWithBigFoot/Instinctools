using Ninject.Modules;

namespace BookStore.Business.Services.Infrastructure.NinjectModules
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
            Bind<IAuthorService>().To<AuthorService>().WithConstructorArgument("connectionString", _connectionString);
            Bind<IBookService>().To<BookService>().WithConstructorArgument("connectionString", _connectionString);
        }
    }
}
