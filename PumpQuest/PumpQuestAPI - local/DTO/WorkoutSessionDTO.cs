using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.DTO
{
    public class CreateWorkoutSessionDTO
    {
        public string CreatorUid { get; set; } = string.Empty;
        public string? BuddyUid { get; set; }
        public int WorkoutId { get; set; }
        public int GymId { get; set; }
        public DateTime Date { get; set; }
    }
    public class WorkoutSessionDTO
    {
        public int Id { get; set; }
        public string CreatorUid { get; set; } = string.Empty;
        public string? BuddyUid { get; set; }
        public int WorkoutId { get; set; }
        public int GymId { get; set; }
        public DateTime Date { get; set; }
        public UserDTO? Creator { get; set; }
        public UserDTO? Buddy { get; set; }
    }

namespace PumpQuestAPI.DTOs
{
    public class ShowSessionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CreatorUid { get; set; } = string.Empty;
        public string CreatorUsername { get; set; } = string.Empty;
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; } = string.Empty;
        public UserStatistics? Statistics { get; set; }

        public static ShowSessionModel FromEntity(WorkoutSession entity)
        {
            return new ShowSessionModel
            {
                Id = entity.Id,
                Date = entity.Date,
                CreatorUid = entity.CreatorUid,
                CreatorUsername = entity.Creator?.Username ?? "Unknown",
                WorkoutId = entity.WorkoutId,
                WorkoutName = entity.Workout?.Name ?? "Unnamed Workout",
                Statistics = entity.Creator?.Statistics
            };
        }
    }
}

}