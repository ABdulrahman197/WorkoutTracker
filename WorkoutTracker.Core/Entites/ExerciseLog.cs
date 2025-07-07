using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkoutTracker.Core.Entites
{
    public class ExerciseLog : BaseEntitiy
    {
      

        public int WorkoutExerciseId { get; set; }
        public WorkoutExercises WorkoutExercise { get; set; } = null!;

        public int SetNumber { get; set; }
        public int ActualRepetitions { get; set; }
        public decimal ActualWeightKg { get; set; }

        public int RPE { get; set; }  // Rate of Perceived Exertion "Intenstiy Measure"
        public int RestTimeSeconds { get; set; }

        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    }
}


//| Set Number | Actual Reps | Weight Used | RPE | Rest Time |
//| ---------- | ----------- | ----------- | --- | --------- |
//| 1          | 10          |   60 kg     | 7   | 90s       |
//| 2          | 8           | 60 kg       | 8   | 120s      |
//| 3          | 6           | 60 kg       | 9   | 120s      |

