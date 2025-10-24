using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.DTO
{
    public class CreateUserDTO
{
    public int Role { get; set; } = 0; // 0 = User, 1 = Trainer, 2 = Admin
    public string Uid { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public int GymId { get; set; }
    public string Email { get; set; } = string.Empty;
    public CreateUserStatisticsDTO Statistics { get; set; } = new CreateUserStatisticsDTO();
}

    public class UserDTO
    {
        public UserRole Role { get; set; } = UserRole.User;
        public string Uid { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public int GymId { get; set; }
        public string Email { get; set; } = string.Empty;
        public UserStatisticsDTO? Statistics { get; set; }
    }

    
}