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
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _context;

        public WorkoutService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutDTO> CreateWorkoutAsync(CreateWorkoutDto workoutDto)
        {
            if (string.IsNullOrWhiteSpace(workoutDto.CoachId))
                throw new ArgumentException("CoachId is required.");

            if (workoutDto.Exercises == null || !workoutDto.Exercises.Any())
                throw new ArgumentException("At least one exercise is required.");

            var exerciseIds = workoutDto.Exercises.Select(e => e.ExerciseId).ToList();

            var coach = await _context.Users.FirstOrDefaultAsync(u => u.Uid == workoutDto.CoachId);
            if (coach == null)
                throw new KeyNotFoundException($"Coach with id {workoutDto.CoachId} not found.");

            var existingExerciseIds = await _context.Exercises
                .Where(e => exerciseIds.Contains(e.Id))
                .Select(e => e.Id)
                .ToListAsync();

            var missing = exerciseIds.Except(existingExerciseIds).Distinct().ToList();
            if (missing.Any())
                throw new KeyNotFoundException($"Missing exercise IDs: {string.Join(", ", missing)}");

            var newWorkout = new Workout
            {
                Name = workoutDto.Name,
                CoachUid = workoutDto.CoachId,
                Trainer = coach,
                WorkoutExercises = workoutDto.Exercises.Select(e => new WorkoutExercise
                {
                    ExerciseId = e.ExerciseId,
                    Sets = e.Sets,
                    Reps = e.Reps
                }).ToList()
            };

            _context.Workouts.Add(newWorkout);
            await _context.SaveChangesAsync();
            return newWorkout.ToDTO();
        }

        public async Task<bool> DeleteWorkoutAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return false;

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }
    
        public async Task<IEnumerable<WorkoutDTO>> GetAllWorkoutsAsync()
        {
            var workouts = await _context.Workouts.Include(w => w.WorkoutExercises).ThenInclude(we => we.Exercise).ToListAsync();
            return workouts.Select(w => w.ToDTO());
        }

        public async Task<WorkoutDTO> GetWorkoutByIdAsync(int workoutId)
        {
            var workout = await _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == workoutId);

            if (workout == null)
            {
                return null!;
            }

            return new WorkoutDTO
            {
                Id = workout.Id,
                Name = workout.Name,
                Description = workout.Description,
                Difficulty = workout.Difficulty,
                Xp = workout.Xp,
                Exercises = workout.WorkoutExercises.Select(we => new WorkoutExerciseDTO
                {
                    ExerciseName = we.Exercise.Name,
                    Sets = we.Sets,
                    Reps = we.Reps
                }).ToList()
            };
        }

        public async Task<WorkoutDTO> GetWorkoutBySessionIdAsync(int sessionId)
        {
            var workout = await _context.WorkoutSessions
                .Where(ws => ws.Id == sessionId)
                .Include(ws => ws.Workout)
                    .ThenInclude(w => w!.WorkoutExercises)  
                        .ThenInclude(we => we.Exercise)
                .Select(ws => ws.Workout)
                .FirstOrDefaultAsync();

            if (workout == null) return null!;

            return new WorkoutDTO
        {
            Id = workout.Id,
            Name = workout.Name,
            Description = workout.Description,
            Difficulty = workout.Difficulty,
            Xp = workout.Xp,
            Exercises = workout.WorkoutExercises.Select(we => new WorkoutExerciseDTO
            {
                ExerciseName = we.Exercise.Name,
                Sets = we.Sets,
                Reps = we.Reps
            }).ToList()
        };
        }
        public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(string userId)
        {
            var workouts = await _context.WorkoutSessions
                .Where(ws => ws.CreatorUid == userId && ws.IsDone)
                .Include(ws => ws.Workout)
                .Select(ws => ws.Workout!)
                .ToListAsync();

            return workouts;
        }
        public async Task<WorkoutDTO> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workout)
        {
            var existingWorkout = await _context.Workouts.FindAsync(id);
            if (existingWorkout == null) return null!;

            existingWorkout.UpdateEntity(workout);
            await _context.SaveChangesAsync();
            return existingWorkout.ToDTO();
        }
    }
}