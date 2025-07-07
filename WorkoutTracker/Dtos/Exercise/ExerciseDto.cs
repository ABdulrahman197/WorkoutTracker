namespace WorkoutTracker.Dtos.Exersise
{
    public class ExerciseDto
    {
        public  int id  { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? MuscleGroup { get; set; }
        public string? EquipmentRequired { get; set; }
        public string? DifficultyLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
