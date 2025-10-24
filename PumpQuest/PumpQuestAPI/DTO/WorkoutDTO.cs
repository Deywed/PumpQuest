using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.DTO
{
    public class WorkoutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int Xp { get; set; }
        public List<WorkoutExerciseDTO> Exercises { get; set; } = new();
    }
public class CreateWorkoutDto
{
    public string Name { get; set; } = string.Empty;
    public string CoachId { get; set; } = string.Empty;
    public List<CreateWorkoutExerciseDto> Exercises { get; set; } = new();
}

public class CreateWorkoutExerciseDto
{
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
}

    public class UpdateWorkoutDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Xp { get; set; }
        public string Difficulty { get; set; } = string.Empty;

    }
    public class ExerciseDetails
    {
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
    public class ExerciseDetailsDTO
    {
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}