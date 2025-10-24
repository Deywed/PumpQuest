using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
    static public class WorkoutSessionMapper
    {
        public static WorkoutSession ToEntity(this CreateWorkoutSessionDTO dto)
        {
            return new WorkoutSession
            {
                CreatorUid = dto.CreatorUid,
                BuddyUid = dto.BuddyUid,
                WorkoutId = dto.WorkoutId,
                GymId = dto.GymId,
                Date = dto.Date
            };
        }

        public static CreateWorkoutSessionDTO ToDTO(this WorkoutSession entity)
        {
            return new CreateWorkoutSessionDTO
            {
                CreatorUid = entity.CreatorUid,
                BuddyUid = entity.BuddyUid,
                WorkoutId = entity.WorkoutId,
                GymId = entity.GymId,
                Date = entity.Date
            };
        }
        
    }
}