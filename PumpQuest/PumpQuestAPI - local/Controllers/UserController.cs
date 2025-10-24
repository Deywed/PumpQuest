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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUser/{uid}")]
        public async Task<IActionResult> GetUser(string uid)
        {
            var user = await _userService.GetUserByIdAsync(uid);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return Ok(createdUser);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("GetUsernameAndXp/{uid}")]
        public async Task<IActionResult> GetUsernameAndXp(string uid)
        {
            var result = await _userService.GetUsernameAndXpByIdAsync(uid);
            if (result == default)
                return NotFound();
            return Ok(new { result.Username, result.Xp });
        }
        [HttpGet("GetUsersByGym/{gymId}")]
        public async Task<IActionResult> GetUsersByGym(int gymId)
        {
            var users = await _userService.GetUsersByGymIdAsync(gymId);
            return Ok(users);
        }

        [HttpGet("GetUsersByRole/{role}")]
        public async Task<IActionResult> GetUsersByRole(UserRole role)
        {
            var users = await _userService.GetUsersByRoleAsync(role);
            return Ok(users);
        }
        [HttpPost("CreateWorkout")]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDto workoutDto)
        {
            var workout = await _userService.CreateWorkoutAsync(workoutDto);
            return Ok(workout);
        }
        [HttpPut("UpdateUserStatistics/{uid}")]
        public async Task<IActionResult> UpdateUserStatistics(string uid, [FromBody] UserStatistics statistics)
        {
            var updatedUser = await _userService.UpdateUserStatisticsAsync(uid, statistics);
            if (updatedUser == null)
                return NotFound();
            return Ok(updatedUser);
        }
        [HttpDelete("DeleteUser/{uid}")]
        public async Task<IActionResult> DeleteUser(string uid)
        {
            var result = await _userService.DeleteUserAsync(uid);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}