using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ProTechniqueInfrastructure.Core.CrossCuttingConcerns.Caching;
using ProTechniqueInfrastructure.Core.Utilities.Interceptors;
using ProTechniqueInfrastructure.Core.Utilities.IoC;

namespace ProTechniqueInfrastructure.Core.Aspects.Autofac.Caching;

public class CacheRemoveAspect: MethodInterception
{
    private string _pattern;
    private ICacheManager? _cacheManager;

    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        _cacheManager.RemoveByPattern(_pattern);
    }
}