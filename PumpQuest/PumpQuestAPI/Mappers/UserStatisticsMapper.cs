using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
    public static class UserStatisticsMapper
    {
        public static UserStatistics ToEntity(this CreateUserStatisticsDTO dto)
        {
            return new UserStatistics
            {
                Height = dto.Height,
                Weight = dto.Weight,
                Age = dto.Age,
                BenchPress = dto.BenchPress,
                Squat = dto.Squat,
                Deadlift = dto.Deadlift,
            };
        }

        // public static UserStatisticsDTO ToDTO(this UserStatistics entity)
        // {
        //     return new UserStatisticsDTO
        //     {
        //         // Id = entity.Id,
        //         // UserUid = entity.UserUid,
        //         // Height = entity.Height,
        //         // Weight = entity.Weight,
        //         // Age = entity.Age,
        //         // BenchPress = entity.BenchPress,
        //         // Squat = entity.Squat,
        //         // Deadlift = entity.Deadlift,
        //         Xp = entity.Xp
        //     };
        // }
        
    }
}
