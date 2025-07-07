using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.BaseSpec;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Core.ModelsSpecs
{
    public class WorkoutExercisesSpecs : Spec<WorkoutExercises>
    {
        public WorkoutExercisesSpecs() 
        {
            includes.Add(e => e.exercises);
            includes.Add(w => w.Workout); 
        }
    }
}
