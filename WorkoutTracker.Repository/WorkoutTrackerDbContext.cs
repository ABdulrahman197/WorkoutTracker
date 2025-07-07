using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Repository
{
    public  class WorkoutTrackerDbContext : IdentityDbContext<ApplicationUser>
    {
        public WorkoutTrackerDbContext(DbContextOptions<WorkoutTrackerDbContext> options) : base(options)
        {
            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Workouts> Workouts { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<WorkoutExercises> WorkoutExercises { get; set; }
        public DbSet<ExerciseLog> ExerciseLogs { get; set; }

    }
}
