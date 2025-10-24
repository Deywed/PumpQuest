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
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<User> CreateUserAsync(CreateUserDTO userDto)
        {
            var newUser = new User
            {
                Uid = userDto.Uid,
                Username = userDto.Username,
                Email = userDto.Email,
                GymId = userDto.GymId,
                Role = (UserRole)userDto.Role,
                Statistics = userDto.Statistics.ToEntity()
            };

            newUser.Statistics.User = newUser;

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<Workout> CreateWorkoutAsync(CreateWorkoutDto dto)
    {
        var coach = await _context.Users.FirstOrDefaultAsync(u => u.Uid == dto.CoachId);
        var ids = dto.Exercises.Select(x => x.ExerciseId).Distinct().ToList();
        var existingIds = await _context.Exercises
            .Where(e => ids.Contains(e.Id))
            .Select(e => e.Id)
            .ToListAsync();

        var workout = new Workout
        {
            Name = dto.Name.Trim(),
            CoachUid = coach!.Uid,
            Trainer = coach,
            WorkoutExercises = dto.Exercises.Select(x => new WorkoutExercise
            {
                ExerciseId = x.ExerciseId,
                Sets = x.Sets,
                Reps = x.Reps
            }).ToList()
        };

        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();

        return workout;
    }

        public async Task<bool> DeleteUserAsync(string uid)
        {
            var user = await _context.Users.FindAsync(uid);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _context.Users.Include(u => u.Statistics).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string uid)
        {
            var user = await _context.Users.Include(u => u.Statistics).FirstOrDefaultAsync(u => u.Uid == uid);
            return user!;
        }

        public async Task<(string Username, double Xp)> GetUsernameAndXpByIdAsync(string uid)
{
    var user = await _context.Users
        .Include(u => u.Statistics)
        .FirstOrDefaultAsync(u => u.Uid == uid);

    if (user == null)
        return ("", 0);

    double xp = 0;
    if (user.Statistics != null)
    {
        xp = user.Statistics.BenchPress + user.Statistics.Squat + user.Statistics.Deadlift;
    }

    return (user.Username, xp);
}

        public Task<List<User>> GetUsersByGymIdAsync(int gymId)
        {
            return _context.Users.Include(u => u.Statistics).Where(u => u.GymId == gymId).ToListAsync();
        }

        public Task<List<User>> GetUsersByRoleAsync(UserRole role)
        {
            return _context.Users.Include(u => u.Statistics).Where(u => u.Role == role).ToListAsync();
        }

        public async Task<User> UpdateUserAsync(string uid, User user)
        {
            var existingUser = await _context.Users.FindAsync(uid);
            if (existingUser == null)
            {
                return null!;
            }

            existingUser.Username = user.Username ?? existingUser.Username;
            existingUser.Email = user.Email ?? existingUser.Email;
            existingUser.Statistics = user.Statistics ?? existingUser.Statistics;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public Task<User> UpdateUserStatisticsAsync(string uid, UserStatistics statistics)
        {
            throw new NotImplementedException();
        }
    }
}