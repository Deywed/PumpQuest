using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.DTO
{
    public class CreateCityDTO
    {
        public string Name { get; set; } = string.Empty;
    }
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}