using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.DTO
{
    public class CreateGymDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int CityId { get; set; }
    }
    public class GymDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}