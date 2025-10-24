using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Services.Interfaces;

namespace PumpQuestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("GetAllWorkouts")]
        public async Task<IActionResult> GetAllWorkouts()
        {
            var workouts = await _workoutService.GetAllWorkoutsAsync();
            return Ok(workouts);
        }

        [HttpGet("GetWorkoutById/{id}")]
        public async Task<IActionResult> GetWorkoutById(int id)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);
            if (workout == null) return NotFound();

            return Ok(workout);
        }
        [HttpPost("CreateWorkout")]
public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDto dto)
{
    try
    {
        var res = await _workoutService.CreateWorkoutAsync(dto);
        return Ok(res);
    }
    catch (KeyNotFoundException knf)
    {
        return BadRequest(new { error = knf.Message });
    }
    catch (ArgumentException argEx)
    {
        return BadRequest(new { error = argEx.Message });
    }
    catch (DbUpdateException dbEx)
    {
        return StatusCode(500, new { error = "A database error occurred.", details = dbEx.Message });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
    }
}

        [HttpPut("UpdateWorkout/{id}")]
        public async Task<IActionResult> UpdateWorkout(int id, [FromBody] UpdateWorkoutDTO workout)
        {
            var updatedWorkout = await _workoutService.UpdateWorkoutAsync(id, workout);
            if (updatedWorkout == null) return NotFound();

            return Ok(updatedWorkout);
        }
        [HttpDelete("DeleteWorkout/{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var result = await _workoutService.DeleteWorkoutAsync(id);
            if (!result) return NotFound();

            return Ok("Deleted successfully");
        }

        [HttpGet("GetWorkoutBySessionId/{sessionId}")]
        public async Task<IActionResult> GetWorkoutBySessionId(int sessionId)
        {
            var workout = await _workoutService.GetWorkoutBySessionIdAsync(sessionId);
            if (workout == null) return NotFound();

            return Ok(workout);
        }
    }
}