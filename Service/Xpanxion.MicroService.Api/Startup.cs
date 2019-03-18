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
using Xpanxion.MicroService.Api.Common.Constants;
using Xpanxion.MicroService.Api.Common.Mapper;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.DataAccess.Repository;
using Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Response;
using Xpanxion.MicroService.Api.Integration.RequestHandler;
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
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            this.RegisterSharedDependencies(services);
            this.RegisterDatabaseContext(services);
            this.RegisterDatabaseRepositories(services);
            this.RegisterRequesValidators(services);
            this.RegisterRequestHandlers(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,  IHostingEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                context.Database.EnsureCreated();
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
        }

        private void RegisterRequestHandlers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRequestHandlerProvider, RequestHandlerProvider>();
            serviceCollection.AddTransient<IRequestHandler<UserRegisterRequest, UserRegisterResponse>, UserRegisterRequestHandler>();
            serviceCollection.AddTransient<IRequestHandler<UserGetRequest, UserGetResponse>, UserGetRequestHandler>();
        }


        #endregion
    }
}
