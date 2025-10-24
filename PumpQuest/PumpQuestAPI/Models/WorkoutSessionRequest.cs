using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PumpQuestAPI.Models
{
    public class WorkoutSessionRequest
    {
        public int Id { get; set; }

    public string SenderUid { get; set; } = string.Empty;
    public string ReceiverUid { get; set; } = string.Empty;
    public int SessionId { get; set; } 
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending";

    [JsonIgnore]
    public User? Sender { get; set; }
    [JsonIgnore]
    public User? Receiver { get; set; }
    [JsonIgnore]
    public WorkoutSession? Session { get; set; }
    }
}