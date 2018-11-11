using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AB.Middleware.HttpRequestLogging;

namespace AB.Middleware.SampleApp
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

            services.AddCorrelationId();
            services.AddClientId();

            services.AddScoped<ScopedClass>();
            services.AddTransient<TransientClass>();
            services.AddSingleton<SingletonClass>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // order matters!
            app.UseMiddleware<HttpRequestLoggingMiddleware>();
            app.UseCorrelationId(CorrelationIdOptions.DefaultOptions);
            app.UseClientId();

            app.UseMvc();
        }
    }
}
