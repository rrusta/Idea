using Idea.Domain.Context;
using Idea.Infrastructure.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Idea.API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ////services.RegisterAutoMapper();
            //services.AddDbContext<IdeaDbContext>(options =>
            //options.UseSqlServer(
            //_config.GetConnectionString("Data Source=.;Initial Catalog=IdeaDb;Integrated Security=True")),
            //ServiceLifetime.Transient);

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Idea", Version = "v1" });
            });
            services.AddControllersWithViews();
            services.AddControllers();
            var connectionString = _config.GetConnectionString("Data Source=.;Initial Catalog=IdeaDb;Integrated Security=True");
            services.AddDbContext<IdeaDbContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=IdeaDb;Integrated Security=True"));
            //services.Configure<FormOptions>(o =>
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = long.MaxValue;
            //    o.MemoryBufferThreshold = int.MaxValue;
            //});

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = ActionContext =>
            //    {
            //        var errors = ActionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
            //        .SelectMany(x => x.Value.Errors)
            //        .Select(x => x.ErrorMessage).ToArray();

            //        var errorResponse = new ApiValidationErrorResponse
            //        {
            //            Errors = errors
            //        };
            //        return new BadRequestObjectResult(errorResponse);
            //    };
            //});
            DependencyContainer.RegisterServices(services);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseStatusCodePagesWithReExecute("api/errors/{0}");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking API V1");
            });
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}