using Catalog.API.Data;
using Catalog.API.Data.Repositories;

namespace Catalog.API;

public static class ProgramExtensions
{
    public static void AddCustomCatalog(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<DatabaseSettingOption>(
            builder.Configuration.GetSection(DatabaseSettingOption.ConfigureName));
        builder.Services.AddScoped<ICatalogContext, CatalogContext>();
        builder.Services.AddTransient<IProductRepository, ProductRepository>();
    }


    public static void UseCustomSwaggerUi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    public static void UseCatalogContextSeed(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var catalogContext = scope.ServiceProvider.GetService<ICatalogContext>();
        CatalogContextSeed.Seed(catalogContext.ProductCollection);
    }
}