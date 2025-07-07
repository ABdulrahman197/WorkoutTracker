using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.Entites;
using System.Linq.Expressions; 

namespace WorkoutTracker.Core.BaseSpec
{
    public class Spec<T> : ISpec<T> where T : BaseEntitiy
    {
        public List<Expression<Func<T, object>>> includes { get; set; } = new List<Expression<Func<T, object>>>();

        
    }
}
