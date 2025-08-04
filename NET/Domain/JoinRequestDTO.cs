using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Models;

namespace NET.Domain
{
    public class JoinRequestDTO
    {
        public int Id { get; set; }
        public int UserAId { get; set; }
        public int UserBId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TrainingSessionId { get; set; }
        public string? Status { get; set; }
    }

    public class CreateJoinRequestDTO
    {
        public int UserAId { get; set; }
        public JoinRequestStatus Status { get; set; } = JoinRequestStatus.Pending;
        public int UserBId { get; set; }
        public int TrainingSessionId { get; set; }
    }

    public class UpdateJoinRequestDTO
    {
        
        public JoinRequestStatus? Status { get; set; }
    }
}