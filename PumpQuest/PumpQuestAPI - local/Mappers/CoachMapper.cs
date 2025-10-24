using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
    static class CoachMapper
    {
        public static CoachDTO ToDTO(this Coach coach)
        {
            return new CoachDTO
            {
                Username = coach.Name,
                Workouts = coach.Workouts.Select(w => w.ToDTO()).ToList()
            };
        }
        public static Coach ToEntity(this CreateCoachDTO dto)
        {
            return new Coach
            {
                Name = dto.Name,
                Bio = dto.Bio,
                Xp = dto.Xp
            };
        }
        public static void UpdateEntity(this Coach coach, UpdateCoachDTO dto)
        {
            coach.Name = dto.Name ?? coach.Name;
            coach.Bio = dto.Bio ?? coach.Bio;
            if(coach.Xp != dto.Xp)
                coach.Xp = dto.Xp;
        }
    }
}