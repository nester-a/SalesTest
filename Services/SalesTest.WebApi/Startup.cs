using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SalesTest.DAL;
using SalesTest.Interfaces.Base.UnitsOfWork;
using SalesTest.Interfaces.UnitsOfWork;
using SalesTest.Interfaces.Services;
using SalesTest.Interfaces.Base.Services;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.SalesTest.Interfaces.Repository;

namespace SalesTest.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SalesTestContext>(opt => opt.UseInMemoryDatabase("SalesTest"));
            services.AddTransient<IRepository<IProduct>, ProductRepository>();
            services.AddTransient<IRepository<IBuyer>, BuyerRepository>();
            services.AddTransient<IRepository<ISalesPoint>, SalesPointRepository>();
            services.AddTransient<ISalesUnitOfWork, SalesUnitOfWork>();
            services.AddTransient<IService<IProduct>, ProductService>();
            services.AddTransient<IService<IBuyer>, BuyerService>();
            services.AddTransient<IService<ISalesPoint>, SalesPointsService>();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SalesTest.WebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SalesTest.WebApi v1"));
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
