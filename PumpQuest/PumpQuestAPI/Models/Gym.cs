using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PumpQuestAPI.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
        public int CityId { get; set; }
        
        [JsonIgnore]
        public City? City { get; set; }
    }
}