using Authentication.WebApi.Context;
using Authentication.WebApi.Jwt;
using Authentication.WebApi.User;
using Authentication.WebApi.User.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Authentication.WebApi
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
            services.AddDbContext<AuthenticationContext>();

            services.TryAddSingleton<ISystemClock, SystemClock>();

            services.AddCors(options => options.AddPolicy(name: "MyPolicyLocalhost",
                                                            builder => builder
                                                            .AllowAnyOrigin()
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod()
                                                            )
                    );

            var builder = services.AddIdentity<AppUser, IdentityRole>()   
                .AddEntityFrameworkStores<AuthenticationContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            services.AddControllers();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicyLocalhost");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
