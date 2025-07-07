using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Core.Entites
{
    public class ApplicationUser : IdentityUser 
    {
        public string DisplayName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Workouts> Workouts { get; set; } = new List<Workouts>();
        public int height_cm { get; set; }
        public decimal weight_kg { get; set; }

    }
}
