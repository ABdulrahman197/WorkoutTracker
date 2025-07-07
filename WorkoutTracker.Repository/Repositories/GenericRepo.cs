using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.BaseSpec;
using WorkoutTracker.Core.Contracts;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Repository.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntitiy
    {
        private readonly WorkoutTrackerDbContext _dbContext;

        public GenericRepo(WorkoutTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Create
        public async Task<bool> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }




        //Delete 
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                return await _dbContext.SaveChangesAsync() > 0;
            }

            return false;

        }




        //Read 
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }




        //read By Id 
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

       


        //update
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }




        public async Task<IEnumerable<ExerciseLog>> GetByWorkoutExerciseIdAsync(int workoutExerciseId)
        {
            return await _dbContext.ExerciseLogs
                .Where(log => log.WorkoutExerciseId == workoutExerciseId)
                .ToListAsync();
        }





        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpec<T> specification)
        {
            return await ApplySpecifications(specification).ToListAsync();
        }


        public async Task<T> GetByIdWithSpecAsync(ISpec<T> specification)
        {
            return await ApplySpecifications(specification).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpecifications(ISpec<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), specification);
        }



     
    }
}
