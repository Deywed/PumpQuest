using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.Domain;
using NET.Mappers;
using NET.Services.Interfaces;

namespace NET.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StatisticsDTO> CreateStatisticsAsync(CreateStatisticsDTO createStatisticsDto)
        {
            var statistics = createStatisticsDto.ToEntity();
            await _context.Statistics.AddAsync(statistics);
            await _context.SaveChangesAsync();

            return statistics.ToDto();
        }

        public async Task<bool> DeleteStatisticsAsync(int id)
        {
            var statistics = await _context.Statistics.FindAsync(id);
            if (statistics == null)
            {
                return false;
            }

            _context.Statistics.Remove(statistics);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<StatisticsDTO>> GetAllStatisticsAsync()
        {
            var statistics = await _context.Statistics.Include(s => s.PersonalRecords).ToListAsync();
            return statistics.Select(s => s.ToDto());
        }

        // public async Task<StatisticsDTO> GetStatisticsByUserId(int id)
        // {
        //     var statistics = await _context.Statistics.Include(s => s.Use)
        //         .FirstOrDefaultAsync(s => s.UserId == id);
        //     if (statistics == null)
        //     {
        //         return null!;
        //     }
        //     return statistics.ToDto();
        // }

        public async Task<StatisticsDTO> UpdateStatisticsAsync(int id, UpdateStatisticsDTO statisticsDto)
        {
            var statistics = await _context.Statistics.FindAsync(id);
            if (statistics == null)
            {
                return null!;
            }

            statistics.UpdateEntity(statisticsDto);
            await _context.SaveChangesAsync();

            return statistics.ToDto();
        }
    }
}