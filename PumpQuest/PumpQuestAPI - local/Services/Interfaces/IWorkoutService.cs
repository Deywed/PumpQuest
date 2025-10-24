using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutDTO>> GetAllWorkoutsAsync();
        Task<WorkoutDTO> GetWorkoutByIdAsync(int id);
        Task<WorkoutDTO> CreateWorkoutAsync(CreateWorkoutDto workout);
        Task<WorkoutDTO> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workout);
        Task<bool> DeleteWorkoutAsync(int id);
        Task<WorkoutDTO> GetWorkoutBySessionIdAsync(int sessionId);
    }
}