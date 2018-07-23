using System;
using System.Reflection;
using EmailSender.Data;
using EmailSender.Data.Infrastructure;
using EmailSender.Data.Repositories.Interfaces;
using EmailSender.Data.Repositories.Logic;
using EmailSender.ResourceModels;
using EmailSender.Services.Interfaces;
using EmailSender.Services.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSender
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
            #region Настройка работы с БД

            var dbConnectionString = Configuration["DbConnectionString"] ?? Configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(options =>
                {
                    options.UseNpgsql(dbConnectionString,
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorCodesToAdd: null);
                        });
                },
                ServiceLifetime.Scoped
            );

            #endregion Настройка работы с БД

            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));

            services.AddScoped<IMailStoryRepository, MailStoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
