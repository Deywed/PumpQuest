using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Mappers
{
    public static class WorkoutMapper
    {
        public static WorkoutDTO ToDTO(this Workout workout)
        {
            return new WorkoutDTO
            {
                Id = workout.Id,
                // Name = workout.Name, Exercises = workout.WorkoutExercises?.Select(we => new ExerciseDetailsDTO
                // {
                //     ExerciseId = we.ExerciseId,
                //     Sets = we.Sets,
                //     Reps = we.Reps
                // }).ToList() ?? new List<ExerciseDetailsDTO>()
                
            };
        }
        // public static Workout ToEntity(this CreateWorkoutDTO dto)
        // {
        //     return new Workout
        //     {
        //         Name = dto.Name
        //     };
        // }
        public static void UpdateEntity(this Workout workout, UpdateWorkoutDTO dto)
        {
            workout.Name = dto.Name ?? workout.Name;
        }
    }
}