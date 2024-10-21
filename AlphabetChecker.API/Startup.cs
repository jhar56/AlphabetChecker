using AlphabetChecker.Service;
using AlphabetChecker.Service.Interface;

namespace AlphabetChecker.API
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
            services.AddControllers();

            // Register the AlphabetCheckerService with DI
            services.AddScoped<IAlphabetCheckerService, AlphabetCheckerService>();

            // Add logging services
            services.AddLogging(config =>
            {
                config.AddConsole();  // Logs to the console
                config.AddDebug();    // Logs to the debug output
            });

            // Register Swagger for API documentation
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlphabetChecker.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            logger.LogInformation("Application started and ready to handle requests.");
        }
    }
}
