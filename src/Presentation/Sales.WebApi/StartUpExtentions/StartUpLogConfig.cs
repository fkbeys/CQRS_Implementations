using Serilog;

namespace Sales.WebApi.StartUpExtentions
{
    public static class StartUpLogConfig
    {
        public static IHostBuilder AddLoggingConfig(this IHostBuilder hostBuilder, IConfiguration configuration)
        {
            hostBuilder.UseSerilog((context, services, config) => config.ReadFrom.Configuration(configuration));
            return hostBuilder;
        }
    }
}
