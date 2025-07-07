namespace WorkoutTracker.Dtos.Workout
{
    public class WorkoutUpdateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Notes { get; set; }
    }
}
