using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public User? Trainer { get; set; }
        public string CoachUid { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
        public int Xp { get; set; }
        public string Difficulty { get; set; } = string.Empty;
    }
}