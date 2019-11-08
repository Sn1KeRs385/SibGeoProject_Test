using System;
using Microsoft.EntityFrameworkCore;

namespace Testing.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<SurveyResult> SurveyResult { get; set; }
    }
}