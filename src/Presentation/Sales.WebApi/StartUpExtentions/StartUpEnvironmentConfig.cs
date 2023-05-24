namespace Sales.WebApi.StartUpExtentions
{
    public static class StartUpEnvironmentConfig
    {
        public static WebApplicationBuilder AddEnvironmentConfig(this WebApplicationBuilder builder, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, true);
            }
            else
            {
                builder.Configuration.AddJsonFile("appsettings.json", optional: false);
            }
            return builder;
        }
    }
}
