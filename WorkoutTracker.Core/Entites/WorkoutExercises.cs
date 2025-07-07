using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Core.Entites
{
    public class WorkoutExercises : BaseEntitiy
    {
     

        public int WorkoutId { get; set; }
        public Workouts Workout { get; set; }    

        public int ExerciseId { get; set; }
        public Exercises exercises { get; set; }      



        public ICollection<ExerciseLog> ExerciseLogs { get; set; } = new List<ExerciseLog>();

        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public decimal WeightKg { get; set; }

        public int? DurationMinutes { get; set; }  //For Cardio Cat 
        public decimal? DistanceKm { get; set; }  // For Running 

        public int OrderInWorkout { get; set; }  //The Order Of Exercise In Workout 
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

    
}
