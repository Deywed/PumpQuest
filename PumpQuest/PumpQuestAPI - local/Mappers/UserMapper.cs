using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
    static public class UserMapper
    {
        public static User ToEntity(this CreateUserDTO dto)
        {
            return new User
            {
                Uid = dto.Uid,
                Username = dto.Username,
                Email = dto.Email,
                Statistics = dto.Statistics.ToEntity(),
                GymId = dto.GymId
            };
        }
        public static CreateUserDTO ToDTO(this User entity)
        {
            return new CreateUserDTO
            {
                Uid = entity.Uid,
                Username = entity.Username,
                Email = entity.Email,
                GymId = entity.GymId
                
            };
        }
    }
}