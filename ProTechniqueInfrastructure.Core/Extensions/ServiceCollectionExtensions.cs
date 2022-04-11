using Microsoft.Extensions.DependencyInjection;
using ProTechniqueInfrastructure.Core.Utilities.IoC;

namespace ProTechniqueInfrastructure.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
    {
        foreach (var module in modules)
        {
            module.Load(services);
        }

        return ServiceTool.Create(services);
    }
}