using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFeedback.Application;
using MyFeedback.Application.Repositories;
using MyFeedback.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MyFeedback.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //  services.AddScoped<IBookingQuery, BookingQuery>();
            services.AddScoped<IExitSlipRepo, ExitSlipRepo>();

            //   services.AddScoped<IAccomodationQuery, AccomodationQuery>();
            //   services.AddScoped<IAccomodationRepository, AccomodationRepository>();

            //   services.AddScoped<IHostQuery, HostQuery>();
            //   services.AddScoped<IHostRepository, HostRepository>();

            //    services.AddScoped<IGuestQuery, GuestQuery>();
            //    services.AddScoped<IGuestRepository, GuestRepository>();

            // DATABASE CONFIGS

             services.AddDbContext<MyFeedbackContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("DefaultConnection"),
                x =>
                    x.MigrationsAssembly("MyFeedback.DatabaseMigration")));


        services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
        {
            var db = p.GetService<MyFeedbackContext>();
            return new UnitOfWork(db);
        });

            return services;
        }
    }
}