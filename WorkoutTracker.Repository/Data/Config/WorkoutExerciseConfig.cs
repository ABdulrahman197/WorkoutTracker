using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Repository.Data.Config
{
    internal class WorkoutExerciseConfig : IEntityTypeConfiguration<WorkoutExercises>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercises> builder)
        {
            builder.Property(w => w.Sets).IsRequired();
            builder.Property(w => w.Repetitions).IsRequired();
            builder.Property(w => w.WeightKg).HasColumnType("decimal(5,2)");

            builder.Property(w => w.DurationMinutes).IsRequired(false);
            builder.Property(w => w.DistanceKm).HasColumnType("decimal(5,2)").IsRequired(false);

            builder.Property(w => w.OrderInWorkout).IsRequired();
            builder.Property(w => w.Notes).HasMaxLength(500);
            builder.Property(w => w.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // العلاقات
            builder.HasOne(w => w.Workout)
                   .WithMany(wk => wk.WorkoutExercises)
                   .HasForeignKey(w => w.WorkoutId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(w => w.exercises)
                   .WithMany()
                   .HasForeignKey(w => w.ExerciseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // العلاقة مع ExerciseLogs
            builder.HasMany(w => w.ExerciseLogs)
                   .WithOne(l => l.WorkoutExercise)
                   .HasForeignKey(l => l.WorkoutExerciseId);

        }
    }
}
