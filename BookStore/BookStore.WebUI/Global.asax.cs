using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using BookStore.Business.Services.Infrastructure.AutomapperProfiles;
using BookStore.WebUI.Infrastructure.AutomapperProfiles;

namespace BookStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(new[] 
            {
                typeof(BaseMappingProfile),
                typeof(DtoViewModelMappingProfile),
                typeof(ViewModelDtoMappingProfile)
            }
            ));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
