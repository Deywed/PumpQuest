using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface IUserStatistics
    {
        Task<UserStatistics> GetStatisticsAsync(int id);
        Task<UserStatistics> UpdateStatisticsAsync(string uid, UpdateUserStatisticsDTO stats);
        Task<UserStatistics> CreateStatisticsAsync(int id, UserStatistics stats);
        Task<UserStatistics> GetStatisticsByUserIdAsync(string uid);
    }
}