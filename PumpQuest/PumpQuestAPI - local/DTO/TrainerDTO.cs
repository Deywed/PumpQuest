using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.DTO
{
    public class TrainerDTO
{
        public string Uid { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<WorkoutDTO> CreatedWorkouts { get; set; } = new List<WorkoutDTO>();
}
}