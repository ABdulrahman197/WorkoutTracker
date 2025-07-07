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
    internal class AppUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(U => U.DisplayName)
                .IsRequired(); 



            builder.HasMany(u => u.Workouts)
               .WithOne(w => w.User)
               .HasForeignKey(w => w.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
