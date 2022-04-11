using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ProTechniqueInfrastructure.Core.CrossCuttingConcerns.Caching;
using ProTechniqueInfrastructure.Core.Utilities.Interceptors;
using ProTechniqueInfrastructure.Core.Utilities.IoC;

namespace ProTechniqueInfrastructure.Core.Aspects.Autofac.Caching;

public class CacheAspect: MethodInterception
{
    private int _duration;
    private ICacheManager? _cacheManager;

    public CacheAspect(int duration = 60)
    {
        _duration = duration;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }
    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(arg => arg?.ToString()??"<Null>"))})";
        if (_cacheManager != null && _cacheManager.IsAdd(key))
        {
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }
        
        invocation.Proceed();
        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }
}