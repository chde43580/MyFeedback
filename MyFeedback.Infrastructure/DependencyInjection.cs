﻿using Microsoft.Extensions.Configuration;
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
using MyFeedback.Application.Query;
using MyFeedback.Infrastructure.Query;


namespace MyFeedback.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExitSlipQuery, ExitSlipQuery>();
            services.AddScoped<IExitSlipRepo, ExitSlipRepo>();
      

            services.AddScoped<IForumPostQuery, ForumPostQuery>();
            services.AddScoped<IForumPostRepo, ForumPostRepo>();
    

            services.AddScoped<ICategoryQuery, CategoryQuery>();
      //    services.AddScoped<ICategoryRepo, CategoryRepo>();

            services.AddScoped<ICommentQuery, CommentQuery>();
            services.AddScoped<ICommentRepo, CommentRepo>();

            services.AddScoped<IAnswerQuery, AnswerQuery>();
            services.AddScoped<IAnswerRepo, AnswerRepo>();

            services.AddScoped<IPastCommentQuery, PastCommentQuery>();
            services.AddScoped<IPastCommentRepo, PastCommentRepo>();

            services.AddScoped<ISchoolQuery, SchoolQuery>();


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