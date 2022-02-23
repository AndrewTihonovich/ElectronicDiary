using ElectronicDiary.BLL.Records;
using ElectronicDiary.BLL.Records.Creater;
using ElectronicDiary.BLL.Records.Deleter;
using ElectronicDiary.BLL.Records.Getter;
using ElectronicDiary.BLL.Records.Updater;
using ElectronicDiary.DAL;
using ElectronicDiary.DAL.Logging;
using ElectronicDiary.WebApi.Middleware;
using ElectronicDiary.WebApi.Models.Record;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ElectronicDiary.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddSingleton<ILoggerProvider, DiaryDbContextLoggerProvider>();

            services.AddScoped<IElectronicDiaryDbContext, ElectronicDiaryDbContext>();
            services.AddScoped<IRecordCreater, RecordCreater>();
            services.AddScoped<IRecordGetter, RecordGetter>();
            services.AddScoped<IRecordUpdater, RecordUpdater>();
            services.AddScoped<IRecordDeleter, RecordDeleter>();
            services.AddScoped<IRecordValidator, RecordValidator>();
            services.AddScoped<IRecordCreateUI, RecordCreateUI>();
            services.AddScoped<IRecordGetUI, RecordGetUI>();
            services.AddScoped<IRecordDeleteUI, RecordDeleteUI>();
            services.AddScoped<IRecordUpdateUI, RecordUpdateUI>();

            services.AddCors(options => options.AddPolicy(name: "MyPolicyLocalhost",
                                                            builder => builder
                                                            .AllowAnyOrigin()
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod()
                                                            )
                    );

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
