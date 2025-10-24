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
    public class GymController : ControllerBase
    {
        private readonly IGymService _gymService;

        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }
        [HttpGet("GetGym/{id}")]
        public async Task<IActionResult> GetGym(int id)
        {
            var gym = await _gymService.GetGymByIdAsync(id);
            if (gym == null)
                return NotFound();

            return Ok(gym);
        }
        [HttpPost("CreateGym")]
        public async Task<IActionResult> CreateGym([FromBody] DTO.CreateGymDTO gym)
        {
            var createdGym = await _gymService.CreateGymAsync(gym);
            return Ok(createdGym);
        }
        [HttpGet("GetAllGymsByCityId/{cityId}")]
        public async Task<IActionResult> GetAllGymsByCityId(int cityId)
        {
            var gyms = await _gymService.GetAllGymsByCityIdAsync(cityId);
            if (gyms == null || !gyms.Any())
                return NotFound();

            return Ok(gyms);
        }

        [HttpDelete("DeleteGym/{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            var result = await _gymService.DeleteGymAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}