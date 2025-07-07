namespace WorkoutTracker.Dtos.Workout
{
    public class WorkoutReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
        public string UserDisplayName { get; set; }
    }
}
