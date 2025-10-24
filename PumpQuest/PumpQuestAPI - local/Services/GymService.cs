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
    
    public class GymService : IGymService
    {
    private readonly ApplicationDbContext _context;

        public GymService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Gym> CreateGymAsync(CreateGymDTO gym)
        {
            var newGym = new Gym
            {
                Name = gym.Name,
                Location = gym.Location,
                CityId = gym.CityId
            };
            await _context.Gyms.AddAsync(newGym);
            await _context.SaveChangesAsync();
            return newGym;
        }

        public async Task<bool> DeleteGymAsync(int id)
        {
            var gym = await _context.Gyms.FindAsync(id);
            if (gym == null)
            {
                return false;
            }

            _context.Gyms.Remove(gym);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GymDTO>> GetAllGymsByCityIdAsync(int cityId)
        {
            var gyms = await _context.Gyms
                .Where(g => g.CityId == cityId)
                .ToListAsync();
            if (gyms == null || gyms.Count == 0)
                return null!;
            var gymsDTO = gyms.Select(g => g.ToDTO()).ToList();
            return gymsDTO;
        }

        public async Task<Gym> GetGymByIdAsync(int id)
        {
            var gym = await _context.Gyms.Include(e => e.Users).FirstOrDefaultAsync(g => g.Id == id);
            if (gym == null)
                return null!;
            return gym;
        }
    }
}