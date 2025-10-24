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
    public class CoachService : ICoachService
    {
        private readonly ApplicationDbContext _context;
        public CoachService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CoachDTO> CreateCoach(CreateCoachDTO coach)
        {
            var newCoach = coach.ToEntity();
            _context.Coaches.Add(newCoach);
            await _context.SaveChangesAsync();
            return newCoach.ToDTO();
        }

        public async Task<bool> DeleteCoach(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
                return false;

            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CoachDTO>> GetAllCoachesWithWorkouts()
{
    // 1️⃣ Učitavamo sve trenere sa njihovim treninzima i vežbama
    var coaches = await _context.Users
        .Where(u => u.Role == UserRole.Trainer)
        .Include(u => u.CreatedWorkouts)
            .ThenInclude(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
        .ToListAsync();

    // 2️⃣ Mapiramo ručno u DTO objekte (ovo se izvršava u memoriji)
    var coachDtos = coaches.Select(u => new CoachDTO
    {
        Uid = u.Uid,
        Username = u.Username,
        Email = u.Email,
        Workouts = u.CreatedWorkouts.Select(w => new WorkoutDTO
        {
            Id = w.Id,
            Name = w.Name,
            Description = w.Description,
            Difficulty = w.Difficulty,
            Xp = w.Xp,
            Exercises = w.WorkoutExercises.Select(we => new WorkoutExerciseDTO
            {
                ExerciseId = we.ExerciseId,
                ExerciseName = we.Exercise?.Name,
                Sets = we.Sets,
                Reps = we.Reps
            }).ToList()
        }).ToList()
    }).ToList();

    return coachDtos;
}

            // var coaches = await _context.Coaches
            //     .Include(c => c.Workouts)
            //     .ToListAsync();

            // return coaches.Select(c => new CoachDTO
            // {
            //     Id = c.Id,
            //     Name = c.Name,
            //     Bio = c.Bio,
            //     Xp = c.Xp,
            //     ImagePath = c.ImagePath,
            //     Workouts = c.Workouts.Select(w => new WorkoutDTO
            //     {
            //         Id = w.Id,
            //         Name = w.Name,
            //         Description = w.Description,
            //         Xp = w.Xp,
            //         Difficulty = w.Difficulty,
                    
            //     }).ToList()
            // }).ToList();

        public async Task<CoachDTO> GetCoachById(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
                return null!;
            return coach?.ToDTO()!;
        }

        public async Task<CoachDTO?> UpdateCoach(int id, UpdateCoachDTO coach)
        {
            var existingCoach = await _context.Coaches.FindAsync(id);
            if (existingCoach == null)
                return null;

            existingCoach.Name = coach.Name;
            existingCoach.Bio = coach.Bio;
            existingCoach.Xp = coach.Xp;

            _context.Coaches.Update(existingCoach);
            await _context.SaveChangesAsync();
            return existingCoach.ToDTO();
        }
    }
}