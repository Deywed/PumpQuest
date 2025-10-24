using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
        Task<ExerciseDTO> GetExerciseByIdAsync(int id);
        Task<IEnumerable<ExerciseDTO>> GetExerciseByWorkoutIdAsync(int workoutId);
        Task<ExerciseDTO> CreateExerciseAsync(CreateExerciseDTO exercise);
        Task<ExerciseDTO> UpdateExerciseAsync(int id, UpdateExerciseDTO exercise);
        Task<bool> DeleteExerciseAsync(int id);
    }
}