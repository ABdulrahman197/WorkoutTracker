using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Core.Entites
{
    public class Workouts : BaseEntitiy
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime ScheduledDate { get; set; } //The Time Should User Workout In 
        public bool Completed { get; set; }         // Workout Completed Or No 
        public DateTime? CompletedAt { get; set; }

        public string?  Notes  { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;



        //Releationships 
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<WorkoutExercises> WorkoutExercises { get; set; } = new List<WorkoutExercises>();  




    }
}
