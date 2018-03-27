using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Site.Lib.Model.DomainModel;
using Site.WebApi.Filters;
using NLog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Site.Common;
using NLog.Web;
using Microsoft.AspNetCore.Http;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Site.Lib.Model.ConfigModel;

namespace Site.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // env.ConfigureNLog(Path.Combine(AppContext.BaseDirectory, "nlog.config"));
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<DianrongConfigModel>(Configuration.GetSection("DianrongConfig"));
            services.AddMvc(opt =>
            {
                opt.Filters.Add(new ApiExceptionFilterAttribute());
                opt.Filters.Add(new DianrongAuthActionFilter(Configuration.GetValue<string>("DianrongConfig:DianrongToken")));
            });

            #region swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "点融", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Site.WebApi.xml"));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Site.Lib.xml"));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Dianrong.Data.xml"));
                c.AddSecurityDefinition("Jwt", new ApiKeyScheme()
                {
                    Description = "JsonWebToken",
                    Type = "apiKey",
                    In = "header",
                    Name = "Authorization"
                });
            });
            #endregion

            #region Autofac
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName() { Name = "Site.Lib" }))
                   .Where(w => w.Name.EndsWith("Service", StringComparison.CurrentCulture))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use((context, next) =>
            {
                context.Request.EnableRewind();
                return next();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Site api");
            });

            app.UseMvc();

        }
    }
}
