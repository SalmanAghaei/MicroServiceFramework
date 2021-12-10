using System.Reflection;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using MSF.Endpoints.Web.StartupExtentions;
using Microsoft.Extensions.DependencyInjection;using MSF.Endpoints.Web.Services;
using MSF.Utilities.Services.Users;

namespace MSF.Endpoints.Web.StartupExtentions
{
    public static class AddMSFServicesExtentions
    {
        public static IServiceCollection AddMSFServices(
            this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch)
        {
           
            services.AddUserInfoService(assembliesForSearch);
      
            return services;
        }


        public static IServiceCollection AddUserInfoService(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch)
        {

            services.AddSingleton<IUserInfoService, WebUserInfoService>();
            //services.Scan(s => s.FromAssemblies(assembliesForSearch)
            //    .AddClasses(classes => classes.Where(type => type.Name == nameof(WebUserInfoService) && typeof(IUserInfoService).IsAssignableFrom(type)))
            //    .AsImplementedInterfaces()
            //    .WithSingletonLifetime());

            return services;
        }
    
    }
}
