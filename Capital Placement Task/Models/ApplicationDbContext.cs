using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
namespace Capital_Placement_Task.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<InterviewStage> InterviewStages { get; set; }
        public DbSet<ProgramApplication> ProgramApplications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
    }
}
