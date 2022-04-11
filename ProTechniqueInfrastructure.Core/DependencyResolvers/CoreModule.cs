using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProTechniqueInfrastructure.Core.CrossCuttingConcerns.Caching;
using ProTechniqueInfrastructure.Core.CrossCuttingConcerns.Caching.Microsoft;
using ProTechniqueInfrastructure.Core.Utilities.IoC;

namespace ProTechniqueInfrastructure.Core.DependencyResolvers;

public class CoreModule: ICoreModule
{
    public void Load(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheManager, MemoryCacheManager>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<Stopwatch>();
    }
}