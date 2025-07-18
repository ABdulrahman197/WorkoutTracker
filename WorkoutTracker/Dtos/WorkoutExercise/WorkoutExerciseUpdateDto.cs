﻿namespace WorkoutTracker.Dtos.WorkoutExercise
{
    public class WorkoutExerciseUpdateDto
    {
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public decimal WeightKg { get; set; }

        public int? DurationMinutes { get; set; }
        public decimal? DistanceKm { get; set; }

        public int OrderInWorkout { get; set; }
        public string? Notes { get; set; }
    }
}
