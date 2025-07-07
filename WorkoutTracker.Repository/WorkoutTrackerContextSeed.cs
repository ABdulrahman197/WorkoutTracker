using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Repository
{
    public class WorkoutTrackerContextSeed
    {
        public static async Task SeedAsync(WorkoutTrackerDbContext Context)
        {

            if (!Context.Exercises.Any())
            {
                var Data = File.ReadAllText("../WorkoutTracker.Repository/Data/DataSeed/exercises.json");
                var DeserializedData = JsonSerializer.Deserialize<List<Exercises>>(Data);

                if (DeserializedData?.Count > 0)
                {
                    foreach (var exercise in DeserializedData)
                    {
                        await Context.Set<Exercises>().AddAsync(exercise);
                    }
                    await Context.SaveChangesAsync();
                }
            }
            
        }
    }
}
