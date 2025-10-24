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
    public class WorkoutSessionController : ControllerBase
    {
        private readonly IWorkoutSessionService _workoutSessionService;

        public WorkoutSessionController(IWorkoutSessionService workoutSessionService)
        {
            _workoutSessionService = workoutSessionService;
        }

        [HttpPost("CreateSession")]
        public async Task<IActionResult> CreateSession([FromBody] CreateWorkoutSessionDTO session)
        {
            if (session == null) return BadRequest();

            var createdSession = await _workoutSessionService.CreateWorkoutSessionAsync(session);
            return Ok(createdSession);
        }
        [HttpGet("GetSessionById/{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {
            var session = await _workoutSessionService.GetWorkoutSessionByIdAsync(id);
            if (session == null) return NotFound();

            return Ok(session);
        }
        [HttpGet("GetAllSessions")]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessions = await _workoutSessionService.GetAllWorkoutSessionsAsync();
            return Ok(sessions);
        }
        [HttpGet("GetSessionByUserId/{uid}")]
        public async Task<IActionResult> GetSessionByUserId(string uid)
        {
            var session = await _workoutSessionService.GetWorkoutSessionByUserIdAsync(uid);
            if (session == null) return NotFound(null);
            return Ok(session);
        }
        [HttpDelete("DeleteSession/{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var result = await _workoutSessionService.DeleteWorkoutSessionAsync(id);
            if (!result) return NotFound();

            return Ok("Deleted successfully");
        }
        [HttpGet("GetSessionsByGymId/{id}")]
        public async Task<IActionResult> GetSessionsByGymId(int id)
        {
            var sessions = await _workoutSessionService.GetWorkoutSessionsByGymIdAsync(id);
            return Ok(sessions);
        }
        [HttpPut("UpdateSession")]
        public async Task<IActionResult> UpdateSession([FromBody] WorkoutSession session)
        {
            if (session == null) return BadRequest();

            var updatedSession = await _workoutSessionService.UpdateWorkoutSessionAsync(session);
            return Ok(updatedSession);
        }

        [HttpPut("MarkSessionAsDone/{id}")]
        public async Task<IActionResult> MarkSessionAsDone(int id)
        {
            var updatedSession = await _workoutSessionService.MarkSessionAsDoneAsync(id);
            return Ok(updatedSession);
        }
    }
}