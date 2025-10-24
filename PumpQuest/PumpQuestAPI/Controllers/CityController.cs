using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Services.Interfaces;

namespace PumpQuestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet("GetCity/{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }
        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityDTO city)
        {
            var createdCity = await _cityService.CreateCityAsync(city);
            return Ok(createdCity);
        }
        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }
        [HttpDelete("DeleteCity/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var result = await _cityService.DeleteCityAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}