using ElectronicDiary.BLL.Records;
using ElectronicDiary.BLL.Records.Creater;
using ElectronicDiary.BLL.Records.Deleter;
using ElectronicDiary.BLL.Records.Getter;
using ElectronicDiary.BLL.Records.Updater;
using ElectronicDiary.DAL;
using ElectronicDiary.DAL.Logging;
using ElectronicDiary.WebApi.Models.Record;
using ElectronicDiary.WebApi.Models.Record.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ElectronicDiary.WebApi
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
