using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

//var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory())
//    .ConfigureAppConfiguration((hostingContext, config) =>
//    {
//        config
//            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
//            .AddJsonFile("appsettings.json", true, true)
//            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
//            .AddJsonFile("ocelot.json")
//            .AddEnvironmentVariables();
//    })
//    .ConfigureServices(s =>
//    {
//        s.AddOcelot();
//    })
//    .ConfigureLogging((ctx, builder) =>
//    {
//        builder.AddConfiguration(ctx.Configuration.GetSection(""));
//        builder.AddConsole();
//        builder.AddDebug();
//    }).UseIISIntegration();
//var app = builder.Build();
//app.UseRouting();
//app.MapGet("/", () => "Hello World!");
//app.UseOcelot().Wait();
//app.Run();
new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            .AddJsonFile("ocelot.json")
            .AddEnvironmentVariables();
    })
    .ConfigureServices(s =>
    {
        s.AddOcelot().AddCacheManager(x => x.WithDictionaryHandle());
    })
    .ConfigureLogging((hostingContext, builder) =>
    {
        builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        builder.AddConsole();
        builder.AddDebug();
    })
    .UseIISIntegration()
    .Configure(app =>
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        });
        app.UseOcelot().Wait();
    })
    .Build()
    .Run();