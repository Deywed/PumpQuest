using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.DTO
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<WorkoutExerciseDTO> WorkoutExercises { get; set; } = new List<WorkoutExerciseDTO>();
    }
    
    public class CreateExerciseDTO
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateExerciseDTO
    {
        public string Name { get; set; } = string.Empty;
    }
    
}