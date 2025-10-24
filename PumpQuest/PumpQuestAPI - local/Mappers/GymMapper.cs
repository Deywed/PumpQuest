using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
   static  public class GymMapper
    {
        public static Gym ToEntity(this CreateGymDTO dto)
        {
            return new Gym
            {
                Name = dto.Name,
                Location = dto.Location,
                CityId = dto.CityId,
                Users = new List<User>()
            };
        }
        public static GymDTO ToDTO(this Gym entity)
        {
            return new GymDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location
            };
        }
    }
}