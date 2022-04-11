using Microsoft.Extensions.DependencyInjection;

namespace ProTechniqueInfrastructure.Core.Utilities.IoC;

public interface ICoreModule
{
    void Load(IServiceCollection services);
}