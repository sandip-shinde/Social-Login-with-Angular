using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Xpanxion.MicroService.Api.CloudServices.Azure;
using Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces;
using Xpanxion.MicroService.Api.Common.Constants;
using Xpanxion.MicroService.Api.Common.Mapper;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.DataAccess.Repository;
using Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces;
using Xpanxion.MicroService.Api.Integration.Contracts;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud;
using Xpanxion.MicroService.Api.Integration.Contracts.Response;
using Xpanxion.MicroService.Api.Integration.Contracts.Response.Cloud;
using Xpanxion.MicroService.Api.Integration.RequestHandler;
using Xpanxion.MicroService.Api.Integration.RequestHandler.CloudHandlers;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;
using Xpanxion.MicroService.Api.RequestValidator;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var storageConnectionString = Configuration["connectionStrings:BlobStorage:Account"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Xpanxion MicroService API",
                    Description = "Xpanxion MicroService API Project",
                });
            });

            RegisterSharedDependencies(services);
            RegisterDatabaseContext(services);
            RegisterDatabaseRepositories(services);
            RegisterRequesValidators(services);
            RegisterRequestHandlers(services);
            RegisterAzureStorageManagers(services);
            RegisterKeyVaultSettings(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                //var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                //context.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller}/{action}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });
            app.UseStaticFiles();
        }

        #region Dependency Registration

        private void RegisterSharedDependencies(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddAutoMapper();
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        private void RegisterDatabaseContext(IServiceCollection serviceCollection)
        {
            // TODO : Add database connection strings here 
            serviceCollection.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString(ApiConstants.ServiceDatabase)));
        }

        private void RegisterDatabaseRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDBRepository<User>, DBRepository<User>>();
            serviceCollection.AddTransient<IDBUnitOfWork, DBUnitOfWork>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
        }

        private void RegisterRequesValidators(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRequestValidatorProvider, RequestValidatorProvider>();
            serviceCollection.AddTransient<IRequestValidator<UserRegisterRequest>, UserRegisterRequestValidator>();
            serviceCollection.AddTransient<IRequestValidator<UserGetRequest>, UserGetRequestValidator>();
            serviceCollection.AddTransient<IRequestValidator<BlobStoragePostRequest>, BlobStoragePostRequestValidator>();
            serviceCollection.AddTransient<IRequestValidator<BlobStorageGetRequest>, BlobStorageGetRequestValidator>();
            serviceCollection.AddTransient<IRequestValidator<ServiceBusPostRequest>, AzureServiceBusPostRequestValidator>();
        }

        private void RegisterRequestHandlers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRequestHandlerProvider, RequestHandlerProvider>();
            serviceCollection.AddTransient<IRequestHandler<UserRegisterRequest, UserRegisterResponse>, UserRegisterRequestHandler>();
            serviceCollection.AddTransient<IRequestHandler<UserGetRequest, UserGetResponse>, UserGetRequestHandler>();
            serviceCollection.AddTransient<IRequestHandler<BlobStoragePostRequest, BlobStoragePostResponse>, BlobStoragePostRequestHandler>();
            serviceCollection.AddTransient<IRequestHandler<BlobStorageGetRequest, BlobStorageGetResponse>, BlobStorageGetRequestHandler>();
            serviceCollection.AddTransient<IRequestHandler<ServiceBusPostRequest, ServiceBusPostResponse>, ServiceBusPostRequestHandler>();
        }

        private void RegisterAzureStorageManagers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBlobStorageManager, BlobStorageManager>();
            serviceCollection.AddTransient<IServiceBusManager, ServiceBusManager>();
        }

        private void RegisterKeyVaultSettings(IServiceCollection serviceCollection)
        {
            Configuration["AppSettings:AzureStorageAccountConnectionString"] = Configuration["connectionStrings:BlobStorage:Account"];
            Configuration["AppSettings:AzureServiceBusConnectionString"] = Configuration["connectionStrings:ServiceBus:Account"];
            serviceCollection.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        #endregion
    }
}
