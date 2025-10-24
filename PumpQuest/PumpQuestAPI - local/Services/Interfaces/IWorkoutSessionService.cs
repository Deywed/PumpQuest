using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface IWorkoutSessionService
    {
        Task<WorkoutSession> CreateWorkoutSessionAsync(CreateWorkoutSessionDTO session);
        Task<WorkoutSession> GetWorkoutSessionByIdAsync(int id);
        Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession session);
        Task<List<WorkoutSession>> GetWorkoutSessionsByGymIdAsync(int id);
        Task<List<WorkoutSession>> GetAllWorkoutSessionsAsync();
        Task<WorkoutSession> GetWorkoutSessionByUserIdAsync(string uid);
        Task<bool> DeleteWorkoutSessionAsync(int id);
        Task<WorkoutSession> MarkSessionAsDoneAsync(int id);
    }
}