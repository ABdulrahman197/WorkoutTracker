﻿namespace WorkoutTracker.Dtos.WorkoutExercise
{
    public class WorkoutExerciseReadDto
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }

        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }

        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public decimal WeightKg { get; set; }

        public int? DurationMinutes { get; set; }
        public decimal? DistanceKm { get; set; }

        public int OrderInWorkout { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
