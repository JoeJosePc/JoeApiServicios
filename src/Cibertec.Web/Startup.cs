using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cibertec.Web.Data;
using Cibertec.Web.Models;
using Cibertec.Web.Services;
using Cibertec.Business;
using Cibertec.UnitOfWork;
using Cibertec.DADapper;
using Cibertec.Business.Rules;

namespace Cibertec.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddSingleton<IUnitOfWork>(options
                => new CibertecUnitOfWork(Configuration.GetConnectionString("CibertecConnection")));
            // Add application services.
            services.AddTransient<IRule, AntiguoProducto>();
            services.AddTransient<IRule, NuevoProducto>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IProductoBusiness, ProductoBusiness>();
            services.AddTransient<ProductoBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            //loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes
                .MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}")
                .MapRoute(
                    name: "Catalogo",
                    template: "Catalogo",
                    defaults: new { Controller = "Producto", Action = "Index" }
                    )
                 .MapRoute(
                    name: "CatalogoDinamico",
                    template: "Catalogo/{id}/{action}",
                    defaults: new { controller = "Producto", action = "Edit" },
                    constraints: new { id = @"\d+" }
                    )
                  .MapRoute(
                    name: "CatalogoSEO",
                    template: "CatalogoSEO/{nombre}/{id}",
                    defaults: new { controller = "Producto", action = "Edit" },
                    constraints: new { id = @"\d+" }
                   );

            });
        }
    }
}
