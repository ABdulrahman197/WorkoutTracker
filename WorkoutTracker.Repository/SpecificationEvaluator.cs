using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.BaseSpec;
using WorkoutTracker.Core.Entites;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WorkoutTracker.Repository
{
    internal class SpecificationEvaluator<T> where T : BaseEntitiy
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery , ISpec<T> spec)
        {
            var Query = InputQuery;

            Query = spec.includes.Aggregate(Query, (current, include) => current.Include(include));
            return Query;
        }
    }
}
