using CreditCalculator;
using CreditCalculator.BLL;
using CreditCalculator.BLL.ScoreCalculators;
using CreditCalculator.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CreditCalculatorAPI
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();

            services.AddSingleton<IEntitiesContext, EntitiesContext>();
            services.AddSingleton<IEntitiesContext, EntitiesContext>();
            services.AddSingleton<IEntitiesRepository, EntitiesRepository>();
            services.AddSingleton<IScoreCorrector, ScoreCorrector>();
            services.AddSingleton<ICreditAmountResolver, CreditAmountResolver>();
            services.AddSingleton<ByAgeScoreCalculator>();
            services.AddSingleton<ByCreditRankScoreCalculator>();
            services.AddSingleton<FamilyExistsAdditionalScoreCalculator>();
            services.AddSingleton<StationarPhoneExistsAdditionalScoreCalculator>();
            services.AddSingleton<HasVisasAdditionalScoreCalculator>();
            services.AddSingleton<HasHouseAdditionalScoreCalculator>();
            services.AddSingleton<HasCarAdditionalScoreCalculator>();
            services.AddSingleton<WasConvictedAdditionalScoreCalculator>();
            services.AddSingleton<HasAnotherCreditAdditionalScoreCalculator>();
            services.AddSingleton<IPersonInfoValidator, PersonInfoValidator>();
            services.AddSingleton<CreditAmountCalculator>();
            services.AddSingleton<IClassResolver, ClassResolverAdapter>();

            services.AddSingleton<ICreditCalculator>(sp =>
            {
                var classResolver = sp.GetService<IClassResolver>();

                var creditCalculator = CreditCalculatorBuilder.Set(classResolver)
                    .FromConfig(CreditAmountCalculatorConfig.Default)
                    .Build();

                return creditCalculator;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
