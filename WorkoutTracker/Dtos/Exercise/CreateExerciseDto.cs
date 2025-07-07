using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Dtos.Exersise
{
    public class CreateExerciseDto
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Category { get; set; }

        [StringLength(50)]
        public string? MuscleGroup { get; set; }

        [StringLength(50)]
        public string? EquipmentRequired { get; set; }

        [StringLength(20)]
        public string? DifficultyLevel { get; set; }

    }
}
