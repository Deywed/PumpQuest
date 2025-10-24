using Microsoft.AspNetCore.SignalR;
using PumpQuestAPI.Data;
using PumpQuestAPI.DTO;
using PumpQuestAPI.DTO.PumpQuestAPI.DTOs;

public class SessionsHub : Hub
{
    private readonly ApplicationDbContext _dbContext;

    public SessionsHub(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task JoinGym(int gymId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"gym-{gymId}");
    }

    public async Task JoinSession(int sessionId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"session-{sessionId}");
    }
public async Task JoinUserGroup(string uid)
{
    await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{uid}");

    // Fetch all upcoming sessions for this user
    var upcomingSessions = _dbContext.WorkoutSessions
        .Where(s => s.BuddyUid == uid || s.CreatorUid == uid)
        .Where(s => s.Date > DateTime.UtcNow)
        .ToList();

    foreach(var session in upcomingSessions)
    {
        await Clients.Caller.SendAsync("NavigateToWorkout", session.Id);
    }
}



    // public async Task RequestSent(int sessionId, string senderUid)
    // {
    //     await Clients.Group(sessionId.ToString()).SendAsync("ReceiveRequestSent", sessionId, senderUid);
    // }
}
