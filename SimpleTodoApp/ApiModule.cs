using InertiaCore.Extensions;
using Microsoft.OpenApi.Models;
using SimpleTodoApp.Data;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace SimpleTodoApp;

[DependsOn(typeof(AbpAspNetCoreModule))]
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpEntityFrameworkCorePostgreSqlModule))]
[DependsOn(typeof(AbpSwashbuckleModule))]
public class ApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(ApiModule).Assembly, opts =>
            {
                opts.RootPath = "todos";
            });
        });
    }
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<TodoAppDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        context.Services.AddControllers();
        context.Services.AddRazorPages();
        context.Services.AddInertia(i =>
        {
            i.RootView = "~/Views/Home/Index.cshtml";

        });
        context.Services.AddViteHelper(vh =>
        { 
            vh.PublicDirectory = "wwwroot";
            vh.ManifestFilename = "manifest.json";
            vh.BuildDirectory = "build";
        });
        
        context.Services.AddAbpSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleTodoApp", Version = "v1" });
            options.DocInclusionPredicate((docName, description) => true);
            options.CustomSchemaIds(type => type.FullName);
            options.CustomOperationIds(opt => $"{opt.ActionDescriptor.RouteValues["controller"]}");
            options.HideAbpEndpoints();
        });
        ConfigurePostgresql();
    }

    private void ConfigurePostgresql()
    {
          Configure<AbpDbContextOptions>(options =>
          {
              options.UseNpgsql();
          });  
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        
        if (env.IsDevelopment())
        {
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseInertia();
        app.UseSwagger();
        app.UseAntiforgery();

        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleTodoApp API");
        });

        app.UseConfiguredEndpoints(opt =>
        {
            opt.MapControllers();
            opt.MapOpenApi();
        });
        
        
    }
}