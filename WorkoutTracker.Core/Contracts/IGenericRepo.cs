using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.BaseSpec;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Core.Contracts
{
    public interface IGenericRepo<T> where T : BaseEntitiy
    {
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<ExerciseLog>> GetByWorkoutExerciseIdAsync(int workoutExerciseId);
        Task<bool> AddAsync(T entity); 
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpec<T> specification);

        Task<T> GetByIdWithSpecAsync(ISpec<T> specification);








    }
}
