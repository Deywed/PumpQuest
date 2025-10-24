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
    public class UserStatisticsController : ControllerBase
    {
        private readonly IUserStatistics _userStatisticsService;
        public UserStatisticsController(IUserStatistics userStatisticsService)
        {
            _userStatisticsService = userStatisticsService;
        }
        [HttpGet("GetStatistics/{id}")]
        public async Task<IActionResult> GetStatistics(int id)
        {
            var stats = await _userStatisticsService.GetStatisticsAsync(id);
            if (stats == null)
                return NotFound();
            return Ok(stats);
        }
        [HttpGet("GetStatisticsByUserId/{uid}")]
        public async Task<IActionResult> GetStatisticsByUserId(string uid)
        {
            var stats = await _userStatisticsService.GetStatisticsByUserIdAsync(uid);
            if (stats == null)
                return NotFound();
            return Ok(stats);
        }
        [HttpPut("UpdateStatistics/{uid}")]
        public async Task<IActionResult> UpdateStatistics(string uid, [FromBody] UpdateUserStatisticsDTO statistics)
        {
    
            var updatedStats = await _userStatisticsService.UpdateStatisticsAsync(uid, statistics);
            if (updatedStats == null)
                return NotFound();
            return Ok(updatedStats);
        }
    }
}