namespace PumpQuestAPI.DTO
{
    public class UserStatisticsDTO
    {
        // public int? Id { get; set; }
        // public string? UserUid { get; set; }
        // public double Height { get; set; }
        // public double Weight { get; set; }
        // public int Age { get; set; }
        // public double BenchPress { get; set; }
        // public double Squat { get; set; }
        // public double Deadlift { get; set; }
        public double Xp { get; set; }
    }
    public class CreateUserStatisticsDTO
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public double BenchPress { get; set; }
        public double Squat { get; set; }
        public double Deadlift { get; set; }
    }
    public class UpdateUserStatisticsDTO
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public int? Age { get; set; }
        public double? BenchPress { get; set; }
        public double? Squat { get; set; }
        public double? Deadlift { get; set; }
    }   
}
