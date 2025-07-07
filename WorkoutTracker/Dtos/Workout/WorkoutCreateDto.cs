namespace WorkoutTracker.Dtos.Workout
{
    public class WorkoutCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Notes { get; set; }
        public string UserId { get; set; }

    }
}
