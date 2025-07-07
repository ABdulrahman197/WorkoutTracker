namespace WorkoutTracker.Dtos.ExerciseLog
{
    public class CreateExerciseLogDto
    {
        public int WorkoutExerciseId { get; set; }
        public int SetNumber { get; set; }
        public int ActualRepetitions { get; set; }
        public decimal ActualWeightKg { get; set; }
        public int RPE { get; set; }
        public int RestTimeSeconds { get; set; }
    }
}
