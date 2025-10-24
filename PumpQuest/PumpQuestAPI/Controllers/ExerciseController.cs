using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Models;
using PumpQuestAPI.Services.Interfaces;

namespace PumpQuestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        [HttpGet("GetAllExercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _exerciseService.GetAllExercisesAsync();
            return Ok(exercises);
        }

        [HttpGet("GetExercisesByWorkoutId/{workoutId}")]
        public async Task<IActionResult> GetExercisesByWorkoutId(int workoutId)
        {
            var exercises = await _exerciseService.GetExerciseByWorkoutIdAsync(workoutId);
            return Ok(exercises);
        }

        [HttpGet("GetExerciseById/{id}")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(id);
            if (exercise == null)
                return NotFound();
            return Ok(exercise);
        }
        [HttpPost("CreateExercise")]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDTO exercise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdExercise = await _exerciseService.CreateExerciseAsync(exercise);
            return Ok(createdExercise);
        }
        [HttpPut("UpdateExercise/{id}")]
        public async Task<IActionResult> UpdateExercise(int id, [FromBody] UpdateExerciseDTO exercise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedExercise = await _exerciseService.UpdateExerciseAsync(id, exercise);
            if (updatedExercise == null)
                return NotFound();
            return Ok(updatedExercise);
        }
        [HttpDelete("DeleteExercise/{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var result = await _exerciseService.DeleteExerciseAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }

    }
}