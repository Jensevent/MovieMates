using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieMates_Backend.DAL;
using MovieMates_Backend.Hubs;
using Microsoft.EntityFrameworkCore;
using MovieMates_Backend.DAL.Db;

namespace MovieMates_Backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = hostingEnvironment;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NewContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DBConnStr")));

            //if (CurrentEnvironment.IsEnvironment("Testing"))
            //{
            //    services.AddDbContext<NewContext>(options => options.UseInMemoryDatabase("TestingDB"));
            //}
            //else
            //{
            //    //services.AddDbContext<NewContext>(options => options("TestingDB"));
            //}
            
            
            services.AddControllers();
            
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("https://localhost:3000/").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
            }));

            services.AddControllers().AddNewtonsoftJson(
                x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
            app.UseCors("ApiCorsPolicy");
           
            
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/hub");
            });
        }
    }
}
