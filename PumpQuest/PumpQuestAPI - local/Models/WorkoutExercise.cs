using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PumpQuestAPI.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        [JsonIgnore]
        public Workout Workout { get; set; } = null!;
        public int ExerciseId { get; set; }
        [JsonIgnore]
        public Exercise Exercise { get; set; } = null!;
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}