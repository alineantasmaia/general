using Autofac.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Compact;

namespace GenMonitorApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                                .Enrich.FromLogContext()
                                .WriteTo.Console()
                                .CreateLogger();

            try
            {
                Log.Information("Staring the Host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host Terminated Unexpectedly");
            }

            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog((cx, cg) =>
                {
                    cg.Enrich.WithProperty("Application", cx.HostingEnvironment.ApplicationName).Enrich.WithProperty("Environment", cx.HostingEnvironment.EnvironmentName).WriteTo.Console(new RenderedCompactJsonFormatter());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:8080")
                              .UseStartup<Startup>();                    
                });                
            
    }
}