﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure
{
    public class MyFeedbackContext : IdentityDbContext<IdentityUser>
    {
        public MyFeedbackContext(DbContextOptions<MyFeedbackContext> options) : base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ExitSlip> ExitSlips { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PastComment> PastComments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }


    }
}
