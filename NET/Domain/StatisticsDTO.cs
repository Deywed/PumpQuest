using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Models;

namespace NET.Domain
{
    public class StatisticsDTO
    {
        public int Id { get; set; }
        public int CollectedPoints { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public ICollection<PRDTO> PersonalRecords { get; set; } = new List<PRDTO>();
    }

    public class CreateStatisticsDTO
    {
        public int CollectedPoints { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }

    public class UpdateStatisticsDTO
    {
        public int? CollectedPoints { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}