using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using DarksoulsApi.Dtos.Mappers.Implementations;
using DarksoulsApi.Dtos.Mappers.Interfaces;
using DarksoulsApi.Repositories.Implementations;
using DarksoulsApi.Repositories.Interfaces;
using DarksoulsApi.Services;
using DarksoulsApi.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace darksouls_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var credentials  = new BasicAWSCredentials(Configuration["AWS_ACCESS_KEY_ID"], Configuration["AWS_SECRET_ACCESS_KEY"]);
            var config = new AmazonDynamoDBConfig { RegionEndpoint = RegionEndpoint.USEast1 };
            var client = new AmazonDynamoDBClient(credentials, config);

            services.AddControllers();
            services.AddSwaggerGen(c =>{
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AWS Serverless Asp.Net Core Web API", Version = "v1" });
            });
            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IBossesRepository, BossesRepository>();
            services.AddSingleton<IBossesService, BossesService>();
            services.AddSingleton<IMapper, Mapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dark Souls 1 API V1");
                c.RoutePrefix = "";
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });
        }
    }
}
