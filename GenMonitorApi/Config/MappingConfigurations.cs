using GenMonitorApi.Models;
using GenCore.Domain;
using Mapster;
using System.Reflection;

namespace GenMonitorApi.Config
{
    public static class MappingConfigurations
    {
        public static void Register(IServiceCollection services)
        {
            TypeAdapterConfig<Knight, KnightModel>.NewConfig().Map(m => m.Id, source => $"{source.Id}");
            TypeAdapterConfig<KnightModel, Knight>.NewConfig().ConstructUsing(f => new Knight());
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetCallingAssembly());
        }
    }
}
