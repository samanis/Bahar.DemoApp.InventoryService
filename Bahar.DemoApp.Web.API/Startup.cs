using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bahar.DemoApp.InventoryService.AppService;
using Bahar.DemoApp.InventoryService.AppService.interfaces;
using Bahar.DemoApp.InventoryService.Model.Repository;
using Bahar.DemoApp.InventoryService.Repository.SQLServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;



namespace Bahar.DemoApp.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            


              .ConfigureApiBehaviorOptions(setupAction =>
               {
                   setupAction.InvalidModelStateResponseFactory = context =>
                   {
                       var problemDetailsFactory = context.HttpContext.RequestServices
                       .GetRequiredService<ProblemDetailsFactory>();

                       var problemDetails = problemDetailsFactory.CreateValidationProblemDetails
                       (context.HttpContext, context.ModelState);

                       problemDetails.Detail = "See the errors field for details.";
                       problemDetails.Instance = context.HttpContext.Request.Path;

                       var actionExecutingContext = context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

                       if (context.ModelState.ErrorCount > 0 &&
                         (context is ControllerContext ||
                          actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                       {
                           problemDetails.Type = "http://Inventory.com/modelvalidationproblem";
                           problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                           problemDetails.Detail = "one or more validation occurred.";


                           return new UnprocessableEntityObjectResult(problemDetails)
                           {
                               ContentTypes = { "application/problem+json" }
                           };

                       };
                       problemDetails.Status = StatusCodes.Status400BadRequest;
                       problemDetails.Title = "One or more error on input occurred.";

                       return new BadRequestObjectResult(problemDetails)
                       {
                           ContentTypes = { "application/problem+json" }
                       };
                   };

               });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<InventoryContext, InventoryContext>();
            services.AddScoped<IinventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryService, InventoryService.AppService.InventoryService>();
            services.AddScoped<IinventoryItemRepository, InventoryItemRepository>();
            services.AddScoped<IInventoryItemService, InventoryItemService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("An un expected fault happened .Try again later.");

                });
                });
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
