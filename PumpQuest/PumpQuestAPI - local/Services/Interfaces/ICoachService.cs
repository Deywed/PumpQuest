using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface ICoachService
    {
        Task<IEnumerable<CoachDTO>> GetAllCoachesWithWorkouts();
        Task<CoachDTO> GetCoachById(int id);
        Task<CoachDTO> CreateCoach(CreateCoachDTO coach);
        Task<CoachDTO?> UpdateCoach(int id, UpdateCoachDTO coach);
        Task<bool> DeleteCoach(int id);
    }
}