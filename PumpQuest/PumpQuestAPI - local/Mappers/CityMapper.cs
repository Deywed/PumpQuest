using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
    static public class CityMapper
    {
        public static City ToEntity(this CreateCityDTO dto)
        {
            return new City
            {
                Name = dto.Name,
                Gyms = new List<Gym>()
            };
        }
        public static CityDTO ToDTO(this City entity)
        {
            return new CityDTO
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}