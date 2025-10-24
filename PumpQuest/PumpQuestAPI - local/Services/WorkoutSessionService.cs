using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.Data;
using PumpQuestAPI.DTO;
using PumpQuestAPI.Mappers;
using PumpQuestAPI.Models;
using PumpQuestAPI.Services.Interfaces;


namespace PumpQuestAPI.Services
{
    public class WorkoutSessionService : IWorkoutSessionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<SessionsHub> _hubContext;
        public WorkoutSessionService(ApplicationDbContext context, IHubContext<SessionsHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<WorkoutSession> CreateWorkoutSessionAsync(CreateWorkoutSessionDTO session)
        {
            var newSession = session.ToEntity();
            await _context.WorkoutSessions.AddAsync(newSession);
            await _context.SaveChangesAsync();

            var fullSession = await _context.WorkoutSessions
                .Include(ws => ws.Workout)
                .Include(ws => ws.Creator)
                    .ThenInclude(u => u!.Statistics)
                .FirstAsync(ws => ws.Id == newSession.Id);

            await _hubContext.Clients.Group($"gym-{fullSession.GymId}")
                .SendAsync("ReceiveSessionCreated", fullSession);

            return fullSession;
        }

        public async Task<bool> DeleteWorkoutSessionAsync(int id)
        {
            var session = await _context.WorkoutSessions.FindAsync(id);
            if (session == null) return false;

            _context.WorkoutSessions.Remove(session);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<WorkoutSession>> GetAllWorkoutSessionsAsync()
        {
            return await _context.WorkoutSessions.ToListAsync();
        }

        public async Task<WorkoutSession> GetWorkoutSessionByIdAsync(int id)
        {
            return await _context.WorkoutSessions.FindAsync(id) ?? throw new Exception("Workout session not found");
        }

        public async Task<List<WorkoutSession>> GetWorkoutSessionsByGymIdAsync(int id)
        {
            var sessions = await _context.WorkoutSessions
                .Include(ws => ws.Workout)
                .Include(ws => ws.Creator)
                    .ThenInclude(u => u!.Statistics)
                .Where(ws => ws.GymId == id && ws.BuddyUid == null && ws.Date >= DateTime.UtcNow && ws.IsDone == false)
                .ToListAsync();

            return sessions;
        }

        public async Task<WorkoutSession> GetWorkoutSessionByUserIdAsync(string uid)
{
    // Sada tražimo sesiju koja pripada korisniku I NIJE završena
    var session = await _context.WorkoutSessions
                              .Include(e => e.Creator)
                              .FirstOrDefaultAsync(ws => ws.CreatorUid == uid && ws.IsDone == false);
    
    if (session == null)
    {
        return null;
    }

    return session;
}

        public async Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession session)
        {
            var existingSession = await _context.WorkoutSessions.FindAsync(session.Id);
            if (existingSession == null) throw new Exception("Workout session not found");
    
            existingSession.BuddyUid = session.BuddyUid ?? existingSession.BuddyUid;
            existingSession.WorkoutId = session.WorkoutId != 0 ? session.WorkoutId : existingSession.WorkoutId;
            existingSession.GymId = session.GymId != 0 ? session.GymId : existingSession.GymId;

            _context.WorkoutSessions.Update(existingSession);
            await _context.SaveChangesAsync();
            return existingSession;
            
        }

        public async Task<WorkoutSession> MarkSessionAsDoneAsync(int id)
        {
            var session = await _context.WorkoutSessions.FindAsync(id);
            if (session == null) throw new Exception("Workout session not found");
            session.IsDone = true;
            _context.WorkoutSessions.Update(session);
            await _context.SaveChangesAsync();
            return session;
        }
    }
}