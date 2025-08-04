using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class StatisticsMapper
    {
        public static StatisticsDTO ToDto(this Statistics statistics)
        {
            if (statistics == null)
            {
                return null!;
            }
            return new StatisticsDTO
            {
                Id = statistics.Id,
                CollectedPoints = statistics.CollectedPoints,
                Height = statistics.Height,
                Weight = statistics.Weight,
                PersonalRecords = statistics.PersonalRecords == null ? new List<PRDTO>() : statistics.PersonalRecords.Select(pr => pr.ToDto()).ToList()
            };
        }

        public static Statistics ToEntity(this CreateStatisticsDTO statisticsDto)
        {
            return new Statistics
            {
                CollectedPoints = statisticsDto.CollectedPoints,
                Height = statisticsDto.Height,
                Weight = statisticsDto.Weight,
            };
        }

        public static void UpdateEntity(this Statistics statistics, UpdateStatisticsDTO updateDto)
        {
            statistics.CollectedPoints = updateDto.CollectedPoints ?? statistics.CollectedPoints;
            statistics.Height = updateDto.Height ?? statistics.Height;
            statistics.Weight = updateDto.Weight ?? statistics.Weight;
        }
    }
}