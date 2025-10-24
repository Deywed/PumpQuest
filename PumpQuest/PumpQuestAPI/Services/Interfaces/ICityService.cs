using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface ICityService
    {
        Task<City> GetCityByIdAsync(int id);
        Task<City> CreateCityAsync(CreateCityDTO city);
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<bool> DeleteCityAsync(int id);
        Task<City> AddGymToCityAsync(int cityId, int gymId);
        
    }
}