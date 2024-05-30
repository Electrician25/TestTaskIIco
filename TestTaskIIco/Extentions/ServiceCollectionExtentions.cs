using TestTaskIIco.CrudService;
using TestTaskIIco.Interfaces;
using TestTaskIIcoServer.CrudService;
using TestTaskIIcoServer.Interfaces;

namespace TestTaskIIcoServer.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddCrudServices(this IServiceCollection services)
        {
            return services.AddTransient<IUserCreatorService, UserCreatorService>()
                .AddTransient<IUserDeleterServicie, UserDeleterServicie>()
                .AddTransient<IUserGetterSerivce, UserGetterSerivce>()
                .AddTransient<IUserUpdaterService, UserUpdaterService>()
                .AddTransient<IUserFinderDublicate, UserFinderDublicate>();
        }
    }
}