using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface IGymService
    {
        Task<Gym> GetGymByIdAsync(int id);
        Task<Gym> CreateGymAsync(CreateGymDTO gym);
        Task<bool> DeleteGymAsync(int id);
        Task<IEnumerable<GymDTO>> GetAllGymsByCityIdAsync(int cityId);
    }
}