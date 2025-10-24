using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int Xp { get; set; }
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
        public string ImagePath { get; set; } = string.Empty;
    }
}