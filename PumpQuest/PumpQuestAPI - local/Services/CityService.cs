using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.Data;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Mappers;
using PumpQuestAPI.Models;
using PumpQuestAPI.Services.Interfaces;

namespace PumpQuestAPI.Services
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<City> AddGymToCityAsync(int cityId, int gymId)
        {
            var city = await _context.Cities
                .Include(c => c.Gyms)
                .FirstOrDefaultAsync(c => c.Id == cityId);

            if (city == null)
                return null!;

            var gym = await _context.Gyms.FindAsync(gymId);
            if (gym == null)
                return null!;

            city.Gyms.Add(gym);
            gym.CityId = cityId;

            await _context.SaveChangesAsync();
            return city;
        }


        public async Task<City> CreateCityAsync(CreateCityDTO city)
        {
            var newCity = new City
            {
                Name = city.Name,
                Gyms = new List<Gym>()
            };
            

            // if (city.Gyms != null)
            // {
            //     foreach (var gym in city.Gyms)
            //     {
            //         var newGym = new Gym
            //         {
            //             Name = gym.Name,
            //             Location = gym.Location,
            //             Users = new List<User>()
            //         };

            //         if (gym.Users != null)
            //         {
            //             foreach (var user in gym.Users)
            //             {
            //                 newGym.Users.Add(new User
            //                 {
            //                     Uid = user.Uid,
            //                     Username = user.Username,
            //                     Email = user.Email,
            //                     GymId = newGym.Id
            //                 });
            //             }
            //         }

            //         newCity.Gyms.Add(newGym);
            //     }
            // }

            await _context.Cities.AddAsync(newCity);
            await _context.SaveChangesAsync();

            return newCity;
        }



        public async Task<bool> DeleteCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
                return false;

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            var cities = _context.Cities;
            return await cities
            .Select(c => c.ToDTO()).ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            var city = await _context.Cities
                .Include(c => c.Gyms)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (city == null)
                return null!;
            return city;
        }


    }
}