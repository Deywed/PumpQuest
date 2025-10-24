using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.Data;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Mappers;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExerciseDTO> CreateExerciseAsync(CreateExerciseDTO exercise)
        {
            var newExercise = exercise.ToEntity();
            _context.Exercises.Add(newExercise);
            await _context.SaveChangesAsync();
            return newExercise.ToDTO();
        }

        public async Task<bool> DeleteExerciseAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
                return false;

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            var exercises = await _context.Exercises.ToListAsync();
            return exercises;
        }

        

        public async Task<ExerciseDTO> GetExerciseByIdAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
                return null!;
            return exercise?.ToDTO()!;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetExerciseByWorkoutIdAsync(int workoutId)
        {
            var exercises = await _context.WorkoutExercises
                .Include(we => we.Exercise)
                .Where(we => we.WorkoutId == workoutId)
                .Select(we => new {
                    ExerciseName = we.Exercise.Name,
                    Sets = we.Sets,
                    Reps = we.Reps
                })
                .ToListAsync();
            return exercises.Select(e => new ExerciseDTO
            {
                Name = e.ExerciseName,
                WorkoutExercises = new List<WorkoutExerciseDTO>
                {
                    new WorkoutExerciseDTO
                    {
                        Sets = e.Sets,
                        Reps = e.Reps
                    }
                }
            });
        }

        public async Task<ExerciseDTO> UpdateExerciseAsync(int id, UpdateExerciseDTO exercise)
        {
            var existingExercise = await _context.Exercises.FindAsync(id);
            if (existingExercise == null)
                return null!;

            existingExercise.UpdateEntity(exercise);
            await _context.SaveChangesAsync();
            return existingExercise.ToDTO();
        }
    }
}