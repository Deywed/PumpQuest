using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PumpQuestAPI.Models
{
    public class UserStatistics
    {
        [Key]
        public int Id { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public double BenchPress { get; set; }
        public double Squat { get; set; }
        public double Deadlift { get; set; }
        public double Xp => BenchPress + Squat + Deadlift;

        [ForeignKey(nameof(User))]
        public string UserUid { get; set; } = string.Empty;

        [JsonIgnore]
        public User? User { get; set; }
                public bool Reward100 { get; set; } = false;
        public bool Reward200 { get; set; } = false;
        public bool Reward300 { get; set; } = false;
        public bool Reward400 { get; set; } = false;
    }
}
