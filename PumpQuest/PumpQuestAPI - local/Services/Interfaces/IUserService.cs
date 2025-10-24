using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(string uid);
        Task<User> CreateUserAsync(CreateUserDTO user);
        Task<User> UpdateUserAsync(string uid, User user);
        Task<bool> DeleteUserAsync(string uid);
        Task<List<User>> GetAllUsersAsync();
        Task<(string Username, double Xp)> GetUsernameAndXpByIdAsync(string uid);
        Task<List<User>> GetUsersByGymIdAsync(int gymId);
        Task<List<User>> GetUsersByRoleAsync(UserRole role);
        Task<Workout> CreateWorkoutAsync(CreateWorkoutDto dto);
        Task<User> UpdateUserStatisticsAsync(string uid, UserStatistics statistics);
    }
}