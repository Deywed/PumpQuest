using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PumpQuestAPI.Models
{
    public enum UserRole
    {
        User = 0,
        Trainer = 1,
        Admin = 2
    }


    public class User
    {
        [Key]
        public string Uid { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; } = UserRole.User;

        public UserStatistics? Statistics { get; set; }

        public int GymId { get; set; }

        [JsonIgnore]
        public Gym? Gym { get; set; }

        [JsonIgnore]
        public List<Workout>? CreatedWorkouts { get; set; }

    }

}
