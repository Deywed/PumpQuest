using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
    public static class ExerciseMapper
    {
        public static ExerciseDTO ToDTO(this Exercise exercise)
        {
            return new ExerciseDTO
            {
                Name = exercise.Name,
                WorkoutExercises = exercise.WorkoutExercises.Select(we => new WorkoutExerciseDTO
                {
                    Sets = we.Sets,
                    Reps = we.Reps,
                }).ToList()
            };
        }
        public static Exercise ToEntity(this CreateExerciseDTO dto)
        {
            return new Exercise
            {
                Name = dto.Name
            };
        }
        public static void UpdateEntity(this Exercise exercise, UpdateExerciseDTO dto)
        {
            exercise.Name = dto.Name ?? exercise.Name;
        }
    }
}