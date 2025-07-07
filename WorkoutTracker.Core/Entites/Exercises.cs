namespace WorkoutTracker.Core.Entites
{
    public class Exercises : BaseEntitiy
    {
      
        public string Name { get; set; } 
        public string? Description { get; set; }

        public string? Category { get; set; }     // Cardio, Strength, etc.
        public string? MuscleGroup { get; set; }     // Chest , Back , 

        public string? EquipmentRequired { get; set; } // Dumbbell ,Barbell 
        public string? DifficultyLevel { get; set; }   // Advanced , Beginner 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<WorkoutExercises> WorkoutExercises { get; set; } = new List<WorkoutExercises>();
    }

}