using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.SignalR;
using PumpQuestAPI.Services.Interfaces;

namespace PumpQuestAPI.Services
{
    public class HangfireService
    {
        private readonly IHubContext<SessionsHub> _hubContext;

        public HangfireService(
            IHubContext<SessionsHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public void ScheduleWorkout(DateTime workoutTime, int sessionId, string user1Uid, string user2Uid)
    {
        var utcTime = workoutTime.ToUniversalTime();

        BackgroundJob.Schedule(
            () => NotifyUsers(sessionId, user1Uid, user2Uid),
            utcTime
        );
    }

    public async Task NotifyUsers(int sessionId, string user1Uid, string user2Uid)
        {
        Console.WriteLine($"Notifying users {user1Uid} and {user2Uid} about workout session {sessionId}");
        await _hubContext.Clients.Group($"user-{user1Uid}")
            .SendAsync("NavigateToWorkout", sessionId);

        await _hubContext.Clients.Group($"user-{user2Uid}")
            .SendAsync("NavigateToWorkout", sessionId);
    }
    }
}