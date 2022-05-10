using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using XgHao.Demo.DependencyInjection.Base.DependencyInjection;

namespace XgHao.Demo.DependencyInjection.Base.Extensions;

/// <summary>
/// ServiceCollection扩展类.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 从程序集加载服务.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddServicesFromAssembly(this IServiceCollection serviceCollection)
    {
        // 加载assembly
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

        // 查找所有Service
        var serviceFiles = Directory.GetFiles(AppContext.BaseDirectory, "XgHao.*Service.*").ToList();
        serviceFiles.ForEach(serviceFile =>
        {
            try
            {
                assemblies.Add(Assembly.LoadFrom(serviceFile));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
        
        // 注册所有实现了IDiService接口的Service
        assemblies.ForEach(assembly =>
        {
            // 不是XgHao前缀的不要
            if (assembly.FullName?.StartsWith("XgHao.") != true)
            {
                return;
            }

            // 获取IDiService的Type
            var serviceTypes = assembly
                .GetTypes()
                .Where(type => !type.IsInterface && typeof(IDiService).IsAssignableFrom(type))
                .ToList();

            // 注册
            serviceTypes.ForEach(serviceType =>
            {
                serviceCollection.AddScoped(serviceType);
                Console.WriteLine($"AddScoped ${serviceType.FullName}");
            });
        });

        return serviceCollection;
    }
}