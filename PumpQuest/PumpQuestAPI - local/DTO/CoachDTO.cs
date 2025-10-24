using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.DTO
{
    public class CoachDTO
    {
    public string Uid { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<WorkoutDTO> Workouts { get; set; } = new();
}
    public class CreateCoachDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int Xp { get; set; }
    }
    public class UpdateCoachDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int Xp { get; set; }
    }
}