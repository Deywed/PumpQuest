using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PumpQuestAPI.Services.Interfaces;

namespace PumpQuestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;
        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        [HttpGet("GetAllCoachesWithWorkouts")]
        public async Task<IActionResult> GetAllCoaches()
        {
            var coaches = await _coachService.GetAllCoachesWithWorkouts();
            return Ok(coaches);
        }
        [HttpGet("GetCoachById/{id}")]
        public async Task<IActionResult> GetCoachById(int id)
        {
            var coach = await _coachService.GetCoachById(id);
            if (coach == null)
                return NotFound();
            return Ok(coach);
        }
        [HttpPost("CreateCoach")]
        public async Task<IActionResult> CreateCoach([FromBody] DTO.CreateCoachDTO coach)
        {
            var createdCoach = await _coachService.CreateCoach(coach);
            return Ok(createdCoach);
        }
        [HttpPut("UpdateCoach/{id}")]
        public async Task<IActionResult> UpdateCoach(int id, [FromBody] DTO.UpdateCoachDTO coach)
        {
            var updatedCoach = await _coachService.UpdateCoach(id, coach);
            if (updatedCoach == null)
                return NotFound();
            return Ok(updatedCoach);
        }
        [HttpDelete("DeleteCoach/{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            var result = await _coachService.DeleteCoach(id);
            if (!result)
                return NotFound();
            return Ok("Deleted successfully");
        }
    }
}