using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PumpQuestAPI.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public string CreatorUid { get; set; } = string.Empty;
        public User? Creator { get; set; }
        public string? BuddyUid { get; set; }
        public User? Buddy { get; set; }
        public int WorkoutId { get; set; }
        public Workout? Workout { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public bool isAlone => string.IsNullOrEmpty(BuddyUid);
        public int GymId { get; set; }
        [JsonIgnore]
        public Gym? Gym { get; set; }
        public bool IsDone { get; set; } = false; 
    }
}