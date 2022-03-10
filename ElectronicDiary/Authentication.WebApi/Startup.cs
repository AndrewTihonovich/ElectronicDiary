using Authentication.WebApi.Context;
using Authentication.WebApi.Jwt;
using Authentication.WebApi.Middleware;
using Authentication.WebApi.User;
using Authentication.WebApi.User.Repository;
using Authentication.WebApi.Validations.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddScoped<IAuthValidator, AuthValidator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a900fae1-70ed-4698-9953-3a247c104366")),
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

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
