﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Core.BaseSpec
{
    public interface ISpec<T> where T : BaseEntitiy
    {
        List<Expression<Func<T,object>>> includes { get; }
    }
}
