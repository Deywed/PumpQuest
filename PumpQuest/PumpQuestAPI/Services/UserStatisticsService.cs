using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.Data;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;
using PumpQuestAPI.Services.Interfaces;

namespace PumpQuestAPI.Services
{
    public class UserStatisticsService : IUserStatistics
    {
        private readonly ApplicationDbContext _context;

        public UserStatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserStatistics> CreateStatisticsAsync(int id, UserStatistics stats)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null!;
            }

            stats.Id = id;
            await _context.UserStatistics.AddAsync(stats);
            await _context.SaveChangesAsync();
            return stats;
        }

        public async Task<UserStatistics> GetStatisticsAsync(int id)
        {
            var stats = await _context.UserStatistics.FindAsync(id);
            return stats!;
        }

        public async Task<UserStatistics> GetStatisticsByUserIdAsync(string uid)
        {
            var stats = await _context.UserStatistics.FirstOrDefaultAsync(s => s.UserUid == uid);
            return stats!;
        }

        public async Task<UserStatistics> UpdateStatisticsAsync(string uid, UpdateUserStatisticsDTO stats)
{
    var user = await _context.Users
        .Include(u => u.Statistics)
        .FirstOrDefaultAsync(u => u.Uid == uid);

    if (user == null)
    {
        return null!;
    }

            // 👇 Ako user nema statistike, kreiraj ih
            if (user.Statistics == null)
            {
                user.Statistics = new UserStatistics
                {
                    UserUid = user.Uid,
                    Height = stats.Height ?? 0,
                    Weight = stats.Weight ?? 0,
                    Age = stats.Age ?? 0,
                    BenchPress = stats.BenchPress ?? 0,
                    Squat = stats.Squat ?? 0,
                    Deadlift = stats.Deadlift ?? 0
                };
                _context.UserStatistics.Add(user.Statistics);
            }
            else
            {
                user.Statistics.Height = stats.Height ?? user.Statistics.Height;
                user.Statistics.Weight = stats.Weight ?? user.Statistics.Weight;
                user.Statistics.Age = stats.Age ?? user.Statistics.Age;
                user.Statistics.BenchPress = stats.BenchPress ?? user.Statistics.BenchPress;
                user.Statistics.Squat = stats.Squat ?? user.Statistics.Squat;
                user.Statistics.Deadlift = stats.Deadlift ?? user.Statistics.Deadlift;
            }

            await CheckAndGenerateReward(user);

    await _context.SaveChangesAsync();
    return user.Statistics;
}
private async Task CheckAndGenerateReward(User user)
{
    var total = user.Statistics!.BenchPress + user.Statistics.Squat + user.Statistics.Deadlift;
    var generator = new RewardPdfGenerator();

    if(total >= 100 && !user.Statistics.Reward100)
    {
        user.Statistics.Reward100 = true;
        var pdf = generator.GenerateRewardPdf(user.Username, total);
        await SavePdfAsync(user.Uid, pdf, 100);
    }

    if(total >= 200 && !user.Statistics.Reward200)
    {
        user.Statistics.Reward200 = true;
        var pdf = generator.GenerateRewardPdf(user.Username, total);
        await SavePdfAsync(user.Uid, pdf, 200);
    }

    if(total >= 300 && !user.Statistics.Reward300)
    {
        user.Statistics.Reward300 = true;
        var pdf = generator.GenerateRewardPdf(user.Username, total);
        await SavePdfAsync(user.Uid, pdf, 300);
    }

    await _context.SaveChangesAsync();
}

private async Task SavePdfAsync(string uid, byte[] pdfBytes, int level)
{
    var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "rewards");
    if(!Directory.Exists(folder)) Directory.CreateDirectory(folder);

    var filePath = Path.Combine(folder, $"{uid}_Reward_{level}.pdf");
    await File.WriteAllBytesAsync(filePath, pdfBytes);
}
    }
}