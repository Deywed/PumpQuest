using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.DTO
{
public class WorkoutExerciseDTO
{
    public int ExerciseId { get; set; }
    public string? ExerciseName { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
}
}